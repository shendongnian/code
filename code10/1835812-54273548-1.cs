    public static void HtmlParser()
    {
        HtmlDocument htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml("Your html string containing tags like <div></div>...");
        HashSet<string> hs = new HashSet<string>();
        foreach(var dec in htmlDoc.DocumentNode.Descendants())
        {
            hs.Add (dec.Name);
        }
    }
