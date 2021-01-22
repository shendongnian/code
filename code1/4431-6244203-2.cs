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
            wbc.DocumentText = "shit of the dummy";        //;magic words        
            HtmlDocument doc = wbc.Document.OpenNew(true);
            doc.Write((string)html);
            this.ReturnString = doc.Body.InnerHtml + " do here something";
            return;
        }
    }
