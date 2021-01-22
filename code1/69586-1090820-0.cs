    namespace WindowsFormsApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.Windows.Forms;
        public partial class Form1 : System.Windows.Forms.Form
        {
            private HtmlDocument document;
            private IDictionary<HtmlElement, string> elementStyles = new Dictionary<HtmlElement, string>();
            public Form1()
            {
                InitializeComponent();
            }
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                this.Text = e.Url.ToString();
                this.document = this.webBrowser1.Document;
                this.document.MouseOver += new HtmlElementEventHandler(document_MouseOver);
                this.document.MouseLeave += new HtmlElementEventHandler(document_MouseLeave);
            }
            private void document_MouseLeave(object sender, HtmlElementEventArgs e)
            {
                HtmlElement element = e.FromElement;
                if (this.elementStyles.ContainsKey(element))
                {
                    string style = this.elementStyles[element];
                    this.elementStyles.Remove(element);
                    element.Style = style;
                }
            }
            private void document_MouseOver(object sender, HtmlElementEventArgs e)
            {
                HtmlElement element = e.ToElement;
                if (!this.elementStyles.ContainsKey(element))
                {
                    string style = element.Style;
                    this.elementStyles.Add(element, style);
                    element.Style = style + "; background-color: #ffc;";
                    this.Text = element.Id ?? "(no id)";
                }
            }
        }
    }
