    private void webBrowserLogin_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowserLogin.Url.ToString() == WebSiteUrl)
            {
                foreach (HtmlElement elem in webBrowserLogin.Document.All)
                {
                    if (elem.Name == "user_name")              // name of the username input
                    {
                        elem.InnerText = UserName;               
                    }
                    if (elem.Name == "password")               // name of the password input
                    {
                        elem.InnerText = Password;                
                    } 
                }
                foreach (HtmlElement elem in webBrowserLogin.Document.All)
                {
                    if (elem.GetAttribute("value") == "Login")
                    {
                        elem.InvokeMember("Click");
                    }
                }
            }
        }
