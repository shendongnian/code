    private static void FormatEmptyNodes(XmlNode rootNode)
    {
        foreach (XmlNode childNode in rootNode.ChildNodes)
        {
            FormatEmptyNodes(childNode);
    
            if(childNode is XmlElement)
            {
                XmlElement element = (XmlElement) childNode;
                if (string.IsNullOrEmpty(element.InnerText)) element.IsEmpty = true;
            }
        }
    }
