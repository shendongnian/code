    XNodeEqualityComparer comparer = new XNodeEqualityComparer();
    XDocument doc = XDocument.Load("XmlFile1.xml");
    Dictionary<int, XNode> nodeDictionary = new Dictionary<int, XNode>();
    
    foreach (XNode node in doc.Elements("doc").Elements("node"))
    {
        int hash = comparer.GetHashCode(node);
        if (nodeDictionary.ContainsKey(hash))
        {
            // A duplicate has been found. Execute your logic here
            // ...
        }
        else
        {
            nodeDictionary.Add(hash, node);
        }
    }
