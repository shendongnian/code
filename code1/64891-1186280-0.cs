    public XmlElement GetXmlElement()
    {
        var doc = new XmlDocument();
        doc.Load(PREFIX + @"Enumerations.wsdl");
        return doc.DocumentElement;
    }
    public XElement GetXElement()
    {
        var doc = XDocument.Load(PREFIX + @"Enumerations.wsdl");
        return doc.Root;
    }
