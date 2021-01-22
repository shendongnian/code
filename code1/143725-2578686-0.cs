    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          webBrowser1.Url = new Uri("http://stackoverflow.com");
          webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }
    
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
          if (!e.Url.Equals(webBrowser1.Url)) return;
          // Get the renderer for the document body
          mshtml.IHTMLDocument2 doc = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument;
          mshtml.IHTMLElement body = (mshtml.IHTMLElement)doc.body;
          IHTMLElementRender render = (IHTMLElementRender)body;
          // Render to bitmap
          using (Bitmap bmp = new Bitmap(webBrowser1.ClientSize.Width, webBrowser1.ClientSize.Height)) {
            using (Graphics gr = Graphics.FromImage(bmp)) {
              IntPtr hdc = gr.GetHdc();
              render.DrawToDC(hdc);
              gr.ReleaseHdc();
            }
            bmp.Save("test.png");
            System.Diagnostics.Process.Start("test.png");
          }
        }
    
        // Replacement for mshtml imported interface, Tlbimp.exe generates wrong signatures
        [ComImport, InterfaceType((short)1), Guid("3050F669-98B5-11CF-BB82-00AA00BDCE0B")]
        private interface IHTMLElementRender {
          void DrawToDC(IntPtr hdc);
          void SetDocumentPrinter(string bstrPrinterName, IntPtr hdc);
        }
      }
    }
