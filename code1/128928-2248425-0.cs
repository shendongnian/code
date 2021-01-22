    private List<string> ExtractAllAHrefTags(HtmlDocument htmlSnippet)
    {
        List<string> hrefTags = new List<string>();
     
        foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
        {
            HtmlAttribute att = link.Attributes["href"];
            hrefTags.Add(att.Value);
        }
     
        return hrefTags;
    }
