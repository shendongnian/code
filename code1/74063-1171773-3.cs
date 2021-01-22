    XmlDocument myDoc = new XmlDocument()
    myDoc.Load(fileName);
    foreach(XmlElement elem in myDoc.SelectNodes("Elements/Element"))
    {
        XmlNode nodeName = elem.SelectSingleNode("Name/text()");
        XmlNode nodeType = elem.SelectSingleNode("Type/text()");
        XmlNode nodeColor = elem.SelectSingleNode("Color/text()");
        string name = nodeName!=null ? nodeName.Value : String.Empty;
        string type = nodeType!=null ? nodeType.Value : String.Empty;
        string color = nodeColor!=null ? nodeColor.Value : String.Empty;
        // Here you use the values for something...
    }
