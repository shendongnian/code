     private static XElement RemoveAllNamespaces(XElement xmlDocument)
            {
                if (!xmlDocument.HasElements)
                {
                    XElement xElement = new XElement(xmlDocument.Name.LocalName);
                    xElement.Value = xmlDocument.Value;
    
                    foreach (XAttribute attribute in xmlDocument.Attributes())
                    {
                        xElement.Add(new XAttribute(attribute.Name.LocalName, attribute.Value));
                    }
    
                    return xElement;
                }
    
                else
                {
                    XElement xElement = new XElement(xmlDocument.Name.LocalName,  xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
                   
                    foreach (XAttribute attribute in xmlDocument.Attributes())
                    {
                        xElement.Add(new XAttribute(attribute.Name.LocalName, attribute.Value));
                    }
    
                    return xElement;
                }
    
        }
