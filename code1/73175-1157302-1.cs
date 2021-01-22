    HtmlDocument doc = webBrowser.Document;
                HtmlElementCollection col = doc.GetElementsByTagName("div");
                foreach (HtmlElement element in col)
                {
                    string cls = element.GetAttribute("className");
                    if (String.IsNullOrEmpty(cls) || !cls.Equals("XYZ"))
                        continue;
    
    
                    HtmlElementCollection childDivs = element.Children.GetElementsByName("ABC");
                    foreach (HtmlElement childElement in childDivs)
                    {
                        //grab links and other stuff same way
                    }
    
                }
