    static void RemoveCdata(XmlNode root)
    {
        foreach (XmlNode n in root.ChildNodes)
        {
            if (n.NodeType == XmlNodeType.CDATA)
                root.RemoveChild(n);
            else if (n.NodeType == XmlNodeType.Element)
                RemoveCdata(n);
        }
    }
    
    ...
    
    RemoveCdata(query);
