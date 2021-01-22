    HtmlDocument doc = webBrowser.Document;
                HtmlElementCollection col = doc.GetElementsByTagName("div");
                foreach (HtmlElement element in col)
                {
                    string cls = element.GetAttribute("class");
                    if (String.IsNullOrEmpty(cls) || !cls.Equals("XYZ"))
                        continue;
    
    
                    HtmlElementCollection childDivs = element.Children;
                    foreach (HtmlElement childElement in childDivs)
                    {
                        //grab links and other stuff same way
                    }
    
                }
