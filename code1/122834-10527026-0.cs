    public static string ExtractText(string html)
    {
        if (html == null)
        {
            throw new ArgumentNullException("html");
        }
    
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
    
        var chunks = new List<string>(); 
    
        foreach (var item in doc.DocumentNode.DescendantNodesAndSelf())
        {
            if (item.NodeType == HtmlNodeType.Text)
            {
                if (item.InnerText.Trim() != "")
                {
                    chunks.Add(item.InnerText.Trim());
                }
            }
        }
        return String.Join(" ", chunks);
    }
