    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    class ParseHTML
    {
        public ParseHTML() { }
        private string ReturnString;
    
        public string doParsing(string html)
        {
            Thread t = new Thread(TParseMain);
            t.ApartmentState = ApartmentState.STA;
            t.Start((object)html);
            t.Join();
            return ReturnString;
        }
    
        private void TParseMain(object html)
        {
            WebBrowser wbc = new WebBrowser();
            wbc.DocumentText = "feces of a dummy";        //;magic words        
            HtmlDocument doc = wbc.Document.OpenNew(true);
            doc.Write((string)html);
            this.ReturnString = doc.Body.InnerHtml + " do here something";
            return;
        }
    }
