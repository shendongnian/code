    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(htmlString);
    var count = new Dictionary<string, int>(); 
    foreach (var node in doc.DocumentNode.Descendants())
    {
        string id = node.GetAttributeValue("id", null);
        if (id != null)
        {
            if (count.ContainsKey(id)) count[id] += 1;
            else count.Add(id, 1); 
        }
    }
    var duplicates = count.Where( id => id.Value > 1 );
