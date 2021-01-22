    public static XAttribute FindAttribute(this XElement element,
        XName subElement, XName attribute)
    {
        return element.Elements(subElement).Attributes(attribute).FirstOrDefault();
    }
