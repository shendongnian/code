    using System;
    using System.Windows.Forms;
    
    namespace WebBrowserDemo
    {
        class Program
        {
            public const string TestUrl = "http://www.w3schools.com/Ajax/tryit_view.asp?filename=tryajax_first";
    
            [STAThread]
            static void Main(string[] args)
            {
                WebBrowser wb = new WebBrowser();
                wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
                wb.Navigate(TestUrl);
    
                while (wb.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
    
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
    
            static void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                WebBrowser wb = (WebBrowser)sender;
                
                HtmlElement document = wb.Document.GetElementsByTagName("html")[0];
                HtmlElement button = wb.Document.GetElementsByTagName("button")[0];
                
                Console.WriteLine(document.OuterHtml + "\n");
    
                button.InvokeMember("Click");
                
                Console.WriteLine(document.OuterHtml);           
            }
        }
    }
