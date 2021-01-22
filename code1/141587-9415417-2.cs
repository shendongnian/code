    using System;
    using System.Windows.Forms;
    // Make sure to add COM reference to "Microsoft HTML Object Library" 
    
    namespace TheAnswer
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Url = new Uri("about:blank");
            }
    
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                MessageBox.Show("Loaded!");
    
                string testHtml = @"
                    <html>
                        <head>
                            <script type=""text/javascript"">
                                var a=2;var b=3;
                                document.write(a+""_""+b);
                            </script>
                        </head>
                        <body>Hello there!</body>
                    </html>";
    
    
                mshtml.IHTMLDocument2 htmlDoc = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument; // IHTMLDocument2 has the write capability (IHTMLDocument3 does not)
                htmlDoc.close();
                htmlDoc.open("about:blank");
    
                object html = testHtml;
                htmlDoc.write(html);
                html = null;
            
            }
    
        }
    }
