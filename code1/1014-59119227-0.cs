    public class HtmlEditor
    {
        WebBrowser webBrowser;
        private dynamic doc;
        private dynamic contentDiv;
        public HtmlEditor(WebBrowser webBrowserControl, string htmlContent)
        {
            webBrowser = webBrowserControl;
            webBrowser.DocumentText = @"<div contenteditable=""true""></div>";
            webBrowser.DocumentCompleted += (s, e) =>
            {
                doc = webBrowser.Document.DomDocument;
                contentDiv = doc.getElementsByTagName("div")[0];
                contentDiv.innerHtml = htmlContent;
            };
        }
        public string HtmlContent => contentDiv.InnerHtml;
        public void Bold() { doc.execCommand("bold", false, null); }
        public void Italic() { doc.execCommand("italic", false, null); }
        public void Underline() { doc.execCommand("underline", false, null); }
        public void OrderedList() { doc.execCommand("insertOrderedList", false, null); }
        public void UnorderedList() { doc.execCommand("insertUnOrderedList", false, null); }
        public void ForeColor(Color color)
        {
            doc.execCommand("foreColor", false, ColorTranslator.ToHtml(color));
        }
        public void BackColor(Color color)
        {
            doc.execCommand("backColor", false, ColorTranslator.ToHtml(color));
        }
        public void InsertImage(Image image)
        {
            var bytes = (byte[])new ImageConverter().ConvertTo(image, typeof(byte[]));
            var src = $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
            doc.execCommand("insertImage", false, src);
        }
        public void Heading(Headings heading)
        {
            doc.execCommand("formatBlock", false, $"<{heading}>");
        }
        public enum Headings { H1, H2, H3, H4, H5, H6 }
    }
