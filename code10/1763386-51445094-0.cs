    using System.Windows.Forms;  // Need this for console app
    namespace ClipboardTest
    {
        class Program
        {
            // Without this attribute, will get null
            [STAThreadAttribute]
            static void Main(string[] args)
            {
                try
                {
                    var clipboardText = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                    Console.WriteLine(clipboardText);
                }
                catch (NullReferenceException ex1)
                {
                    // Handle error
                }
                catch (System.Threading.ThreadStateException ex2)
                {
                    // Will throw this when:
                    // "The current thread is not in single-threaded apartment (STA) mode and the Application.MessageLoop property value is true."
                    // Handle error
                }
                catch (System.Runtime.InteropServices.ExternalException ex3)
                {
                    // Will throw this if clipboard in use
                    // Handle error
                }
            }
        }
    }
