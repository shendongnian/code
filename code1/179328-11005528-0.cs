       foreach (string mul in masterurlList)
                {
                    List<string> hrefTags = new List<string>();
                    try
                    {
                    HtmlWeb hwObject = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument htmldocObject = hwObject.Load(mul);
                        hrefTags = ExtractAllAHrefTags(htmldocObject);
                    }
                    catch (Exception)
                    { }
                }
