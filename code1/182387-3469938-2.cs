    private static XElement Sort(XElement element)
    {
        return new XElement(element.Name,
                element.Attributes(),
                from child in element.Nodes()
                where child.NodeType != XmlNodeType.Element
                select child,
                from child in element.Elements()
                orderby child.Name.ToString()
                select Sort(child));
    }
    private static XDocument Sort(XDocument file)
    {
        return new XDocument(
                file.Declaration,
                from child in file.Nodes()
                where child.NodeType != XmlNodeType.Element
                select child,
                Sort(file.Root));
    }
