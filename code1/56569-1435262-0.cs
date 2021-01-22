    XDocument LoadWithPrefix(Stream stream)
    {
        XmlNamespaceManager mgr = new XmlNamespaceManager(new NameTable());
        mgr.AddNamespace("a", "http://foo/bar");
        XmlParserContext ctx = new XmlParserContext(null, mgr, null, XmlSpace.Default);
        using (XmlReader reader = XmlReader.Create(stream, null, ctx)) 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            return XDocument.Parse(doc.OuterXml);
        }
    }
