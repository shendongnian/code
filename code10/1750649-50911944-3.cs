    public static XElement GetElement(this XElement element, string elementName)
    {
        if (!element.HasElements)
            throw new HasNoElementsException("");
    
        return element.Elements().FirstOrDefault(e => e.Name.LocalName.Equals(elementName)) ??
            throw new ElementNotFoundException("");
    }
