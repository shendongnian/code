    public static string RemoveAllNamespaces(string xmlDocument)
    {
        var xml = XElement.Parse(xmlDocument);
        xml.Descendants().Select(o => o.Name = o.Name.LocalName).ToArray();
        return xml.ToString();
    }
