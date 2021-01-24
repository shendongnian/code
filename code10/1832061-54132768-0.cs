    public static string TransformXMLToHTML(string inputXml, string xsltString)
    {
        XslCompiledTransform transform = new XslCompiledTransform();
        using(XmlReader reader = XmlReader.Create(new StringReader(xsltString))) {
            transform.Load(reader);
        }
        StringWriter results = new StringWriter();
        using(XmlReader reader = XmlReader.Create(new StringReader(inputXml))) {
            transform.Transform(reader, null, results);
        }
        return results.ToString();
    }
