        Foo foo = new Foo();
        // ...populate foo here...
        var builder = new System.Text.StringBuilder();
        var settings = new System.Xml.XmlWriterSettings { OmitXmlDeclaration = true, Indent= true };
        var ns = new XmlSerializerNamespaces();
        ns.Add("","");
        XmlSerializer s = new XmlSerializer(typeof(Foo));
        using ( var writer = System.Xml.XmlWriter.Create(builder, settings))
        {
            s.Serialize(writer, foo, ns);
        }
        string rawXml = builder.ToString();
