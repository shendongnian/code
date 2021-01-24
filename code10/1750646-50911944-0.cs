    public static XElement GetElement(this XElement element, string elementName)
    {
        if (!element.HasElements)
            throw new ElementNotFoundException("");
    
        return element.Element(element.Elements().First(e => e.Name.LocalName.Equals(elementName))?.GetDefaultNamespace() + elementName) ??
            throw new ElementNotFoundException("");
    }
