     while (run)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        foreach (HtmlElement el in web_Browser.Document.GetElementsByTagName("р"))
                        {
                            if (el.GetAttribute("title") == "Custom") != null)
                            {
                               run = false;
                            }
                        }
                    }
