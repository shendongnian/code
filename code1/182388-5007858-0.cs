    private static XElement Sort(XElement element)
    {
        XElement newElement = new XElement(element.Name,
            from child in element.Elements()
            orderby child.Name.ToString()
            select Sort(child));
        if (element.HasAttributes)
        {
            foreach (XAttribute attrib in element.Attributes())
            {
                newElement.SetAttributeValue(attrib.Name, attrib.Value);
            }
        }
        return newElement;
    }
    private static XDocument Sort(XDocument file)
    {
        return new XDocument(Sort(file.Root));
    }
