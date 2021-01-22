    string input = "<?xml version=\"1.0\"?> ...";
    string output;
    using (StringReader sReader = new StringReader(input))
    using (XmlReader xReader = XmlReader.Create(sReader))
    using (StringWriter sWriter = new StringWriter())
    using (XmlWriter xWriter = XmlWriter.Create(sWriter))
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("transform.xsl");
        xslt.Transform(xReader, xWriter);
        output = sWriter.ToString();
    }
