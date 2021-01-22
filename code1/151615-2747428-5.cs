    using System;
    using System.Windows;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
      class Program
      {    
        [STAThread] 
        static void Main(string[] args)
        {      
          Application.Run(new BrowserWindow());   
          
          Console.ReadKey();
        }
      }
    
      class BrowserWindow : Form
      {
        public BrowserWindow()
        {
          ShowInTaskbar = false;
          WindowState = FormWindowState.Minimized;
          Load += new EventHandler(Window_Load);
        }
    
        void Window_Load(object sender, EventArgs e)
        {      
          WebBrowser wb = new WebBrowser();
          wb.AllowNavigation = true;
          wb.DocumentCompleted += wb_DocumentCompleted;
          wb.Navigate("http://www.bing.com");      
        }
    
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
          Console.WriteLine("We have Bing");
        }
      }
    }
