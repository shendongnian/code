    //Implemented based on interface, not part of algorithm
    public static string RemoveAllNamespaces(string xmlDocument)
    {
        XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));
        return xmlDocumentWithoutNs.ToString();
    }
    //Core recursion function
    private static XElement RemoveAllNamespaces(XElement xmlDocument)
    {
        if (!xmlDocument.HasElements)
        {
            XElement xElement = new XElement(xmlDocument.Name.LocalName);
            xElement.Value = xmlDocument.Value;
            return xElement;
        }
        return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
    }
