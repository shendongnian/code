    using System.Windows.Forms;
    using System.IO;
    namespace stackoverflow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                var path = Path.Combine(System.Environment.CurrentDirectory, "test.html");
                var page = System.IO.File.ReadAllText(path);
                webBrowser1.Navigate(path);
                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            }
            private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var newScript = webBrowser1.Document.CreateElement("script");
                webBrowser1.Document.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterEnd, newScript);
                var path =Path.Combine(System.Environment.CurrentDirectory, "test.js");
                var script =File.ReadAllText(path);
                newScript.InnerText = script;
            }
        }
    }
