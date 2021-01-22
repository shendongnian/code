    public string GetInnerXml(object o)
    {
        string val = String.Empty;
        XmlNode parent = o as XmlNode;
        XmlNode child = parent.SelectSingleNode("bob/fred");
        if (child != null)
            val = child.InnerXml;
        return val;
    }
