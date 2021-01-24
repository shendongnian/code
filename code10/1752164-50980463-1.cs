    while (mylist.Count > 0)
                {
                    var url = mylist..Dequeue();
                    //the items in mylist are added to the url
                    var urls = "http://example.com" + url;
    
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument document = web.Load(urls);
    
                    HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[contains(@class,'Name')]/a");
                    foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>)nodes)
                    {
                        if (!mylist.Contains(htmlNode.InnerText))
                        { 
                            mylist.Enqueue(htmlNode.InnerText);
                        }
    
                    }
    
    
                }
