    private static XPathDocument TransformToXPathDocument(string styleSheetPath,
                                                          IXPathNavigable xPathDoc)
    {
        var xsl = new XslCompiledTransform();
        xsl.Load(styleSheetPath);
        using(var stringWriter = new StringWriter())
        {
            using(XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
            {
                xsl.Transform(xPathDoc, xmlWriter);
            }
            using(var reader = new StringReader(stringWriter.ToString()))
            {
                return new XPathDocument(reader);
            }
        }
    }
