    public static string XmlEscape(string unescaped)
    {
        XmlDocument doc = new XmlDocument();
        var node = doc.CreateElement("root");
        node.InnerText = unescaped;
        doc.AppendChild(node);
        return doc.FirstChild.InnerXml;
    }
    public static string XmlUnescape(string escaped)
    {
        XmlDocument doc = new XmlDocument();
        var node = doc.CreateElement("root");
        node.InnerXml = escaped;
        doc.AppendChild(node);
        return doc.FirstChild.InnerText;
    }
