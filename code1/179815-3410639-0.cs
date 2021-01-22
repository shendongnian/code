    public static string GetAttributeValue(this XElement element, XName name)
    {
        var attribute = element.Attribute(name);
        return attribute != null ? attribute.Value : null;
    }
