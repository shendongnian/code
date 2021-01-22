    private static XElement RemoveAllNamespaces(XElement xmlDocument)
    {
        XElement xElement;
    
        if (!xmlDocument.HasElements)
        {
            xElement = new XElement(xmlDocument.Name.LocalName) { Value = xmlDocument.Value };
        }
        else
        {
            xElement = new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(x => RemoveAllNamespaces(x)));
        }
    
        foreach (var attribute in xmlDocument.Attributes())
        {
            if (!attribute.IsNamespaceDeclaration)
            {
                xElement.Add(attribute);
            }
        }
    
        return xElement;
    }
