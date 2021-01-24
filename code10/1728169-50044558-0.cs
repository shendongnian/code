        private static void Br_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Retrieve string content of document
            var document = ((WebBrowser)sender).Document;
            var documentAsIHtmlDocument3 = (mshtml.IHTMLDocument3)document.DomDocument;
            var content = documentAsIHtmlDocument3.documentElement.innerHTML;
            if (((WebBrowser)sender).Url.AbsoluteUri.Contains("startpage.aspx")) 
            {
     
                //Click on button
                ((WebBrowser)sender).ScriptErrorsSuppressed = true;
                ((WebBrowser)sender).Document.GetElementById("myId").InvokeMember("Click");
            }
            else if (((WebBrowser)sender).Url.AbsoluteUri.Contains("page1.aspx")) 
            {
                ((WebBrowser)sender).Document.GetElementById("btn_send").InvokeMember("Click");
            }
            else if (((WebBrowser)sender).Url.AbsoluteUri.Contains("page2.aspx")) 
            {
                //Some code
                Application.ExitThread();
            }   
        }
  
