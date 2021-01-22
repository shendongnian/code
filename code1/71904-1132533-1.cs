    public static string XmlEscape(string unescaped)
    {
        XmlDocument doc = new XmlDocument();
        var node = doc.CreateElement("root");
        node.InnerText = unescaped;
        return node.InnerXml;
    }
    public static string XmlUnescape(string escaped)
    {
        XmlDocument doc = new XmlDocument();
        var node = doc.CreateElement("root");
        node.InnerXml = escaped;
        return node.InnerText;
    }
