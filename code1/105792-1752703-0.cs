    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                HtmlDocument doc = null;
                doc = webBrowser1.Document;
    
                //Find login text box and write user name  
                HtmlElement login = doc.GetElementById("username_or_email");
                login.InnerText = this.login;
    
                //Find password text box and write password
                HtmlElement password = doc.GetElementById("session[password]");
                password.InnerText = this.password;
    
                // go to the submit button
                webBrowser1.Document.GetElementsByTagName("input")[5].Focus();
                SendKeys.Send("{ENTER}");
    
            }
