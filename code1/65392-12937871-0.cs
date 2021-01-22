    internal void LoginToSite()
            {
                WebBrowser.Navigate("some site login Page");
                _Processing = true;
                var username = ConfigurationManager.AppSettings["username"];
                var password = ConfigurationManager.AppSettings["password"];
                while (_Processing)
                {
                    Application.DoEvents();
                    if (WebBrowser.ReadyState == WebBrowserReadyState.Complete || WebBrowser.ReadyState == WebBrowserReadyState.Interactive)
                    {
                        var htmlDocument = this.WebBrowser.Document;
                        if (htmlDocument != null)
                        {
                            foreach (HtmlElement tag in htmlDocument.GetElementsByTagName("input"))
                            {
                                switch (tag.Name)
                                {
                                    case "username":
                                        tag.InnerText = username;
                                        break;
                                    case "password":
                                        tag.InnerText = password;
                                        break;
                                    case "cmdlogin":
                                        tag.RaiseEvent("onclick");
                                        tag.InvokeMember("Click");
                                        break;
                                }
    
                            }
                        }
                        _Processing = false;
                    }
                }
            }
