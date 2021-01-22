    XmlNodeList nodes = xmlDocument.GetElementsByTagName("Node1");
    foreach(XmlNode node in nodes)
    {
        if(node.ChildNodes.Count == 0)
             node.RemoveAll;
        else
        {
            foreach (XmlNode n in node)
            {
                if(n.InnerText==String.Empty && n.Attributes.Count == 0)
                {
                    n.RemoveAll;
                    
                }
            }
        }
    }
