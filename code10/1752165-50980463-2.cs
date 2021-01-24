    using HtmlAgilityPack;
    
    Queue<string> mylist = new Queue<string>();
    var firstUrl = "http://example.com";
    HtmlWeb web = new HtmlWeb();
    HtmlDocument document = web.Load(firstUrl);
    
    HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[contains(@class,'Name')]/a");
                foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>)nodes)
                {
                    if (!mylist.Contains(htmlNode.InnerText))
                    {
                        mylist.Enqueue(htmlNode.InnerText);
    
                    }
                }
