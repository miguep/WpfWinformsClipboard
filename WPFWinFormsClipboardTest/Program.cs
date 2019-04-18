using System;
using WPF = System.Windows;
using WinForms = System.Windows.Forms;

namespace WPFWinFormsClipboardTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Registers the custom format if it's not already registered.
            string customFormatName = "CustomFormat";
            WPF.DataFormat registeredFormat = WPF.DataFormats.GetDataFormat(customFormatName);
            Console.WriteLine(String.Format("WPF registered format \'{0}\', got id \'{1}\'", customFormatName, registeredFormat.Id));

            // Set data using the custom format.
            string dataToWrite = "test data";
            WPF.Clipboard.SetData(registeredFormat.Name, dataToWrite);
            // Flush data to clipboard.
            WPF.Clipboard.Flush();

            Console.WriteLine(String.Format("WPF wrote \'{0}\' to clipboard", dataToWrite));

            // Get the custom format using the id from the registered custom format.
            System.Windows.Forms.DataFormats.Format format = System.Windows.Forms.DataFormats.GetFormat(registeredFormat.Id);
            Console.WriteLine(String.Format("Winforms got format data using id from WPF registered format, got \'{0}\'", format.Name));
            // Get the data under that format.
            string data = System.Windows.Forms.Clipboard.GetData(format.Name) as string;
            Console.WriteLine(String.Format("Winforms got data from clipboard, got \'{0}\'", data));
        }
    }
}
