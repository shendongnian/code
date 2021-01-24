    public IEnumerable<string> Scrap(string url)
    {
        var web = new HtmlWeb();
        var seenUrls = new HashSet<string>();
        return ScrapImpl(web, seenUrls, url);
    }
    private IEnumerable<string> ScrapImpl(HtmlWeb web, HashSet<string> seenUrls, string baseUrl)
    {
        var document = web.Load(baseUrl);
        foreach (var node in document.DocumentNode.SelectNodes("//div[contains(@class,'Name')]/a"))
        {
            yield return node.InnerText;
            if (seenUrls.Add(node.InnerText))
            {
                foreach (var childUrl in ScrapImpl(web, seenUrls, baseUrl + node.InnerText))
                {
                    yield return childUrl;
                }
            }
        }
    }
