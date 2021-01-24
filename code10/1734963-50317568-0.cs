    HtmlElementCollection classButton = webBrowser1.Document.All;
                foreach (HtmlElement element in classButton)
                {
                    if (element.GetAttribute("classname") == "jfk-button-img")
                    {
                        element.InvokeMember("click");
                    }
                }
