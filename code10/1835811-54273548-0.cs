    public static void HtmlParser()
    {
        //...
        HashSet<string> hs = new HashSet<string>();
        foreach(var dec in htmlDoc.DocumentNode.Descendants())
        {
            hs.Add (dec.Name);
        }
    }
