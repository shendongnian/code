        Foo foo = new Foo();
        // ...populate foo here...
        var builder = new System.Text.StringBuilder();
        XmlSerializer s = new XmlSerializer(typeof(Foo));
        using ( var writer = System.Xml.XmlWriter.Create(builder))
        {
            s.Serialize(writer, foo, ns);
        }
        string rawXml = builder.ToString();
