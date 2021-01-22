    public static XElement ToXML(this Dictionary<string, object> dic, string firstNode)
    {
        IList<XElement> xElements = new List<XElement>();
        foreach (var item in dic)
            xElements.Add(new XElement(item.Key, GetXElement(item.Value)));
        XElement root = new XElement(firstNode, xElements.ToArray());
        return root;
    }
    
    private static object GetXElement(object item)
    {
        if (item != null && item.GetType() == typeof(Dictionary<string, object>))
        {
            IList<XElement> xElements = new List<XElement>();
            foreach (var item2 in item as Dictionary<string, object>)
                xElements.Add(new XElement(item2.Key, GetXElement(item2.Value)));
    
            return xElements.ToArray();
        }
    
        return item;
    }
