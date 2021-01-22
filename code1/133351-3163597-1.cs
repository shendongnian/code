                    var theElementCollection = webBrowser.Document.GetElementsByTagName("select");
                    foreach (HtmlElement el in theElementCollection)
                    {
                        if (el.GetAttribute("value").Equals("13963"))
                        {
                            el.SetAttribute("selected", "selected");
                            //el.InvokeMember("click");
                        }
                    }
