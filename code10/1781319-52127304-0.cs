    HtmlElementCollection d0cument = homeBrowser.Document.GetElementsByTagName("button");
                foreach (HtmlElement link in d0cument)
                {
                    String class2 = link.InnerText;
                    if (class2 == "Login")
                    {
                        link.InvokeMember("click");
                        logincheck.Enabled = true;
                    }
                }
