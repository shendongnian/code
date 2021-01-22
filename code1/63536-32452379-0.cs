    public static XElement RemoveAllNamespaces(this XElement element)
    {
        return new XElement(element.Name.LocalName,
                            element.HasAttributes ? element.Attributes().Select(a => new XAttribute(a.Name.LocalName, a.Value)) : null,
                            element.HasElements ? element.Elements().Select(e => RemoveAllNamespaces(e)) : null,
                            element.Value);
    }
