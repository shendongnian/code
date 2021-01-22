    var nodes = sourceDocument.DocumentNode.SelectNodes("//span[@id]");
    List<string> ids = new List<string>(nodes.Count);
    
    if(nodes != null)
    {
        foreach(var node in nodes)
        {
            if(node.Id != null)
            ids.Add(node.Id);
        }
    }
    
    return ids;
