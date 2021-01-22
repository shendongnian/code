        XElement element = null; // Insert the XElement here;
        Assembly assembly = Assembly.GetExecutingAssembly();
        // you can use reflector to get the full namespace of your embedded resource here
        Stream stream = assembly.GetManifestResourceStream("AssemblyRootNamespace.Resources.XMLSchema.xsd");
        XmlSchemaSet schemas = new XmlSchemaSet();
        schemas.Add(null, XmlReader.Create(stream));
        var doc = new XDocument(element);
        doc.Validate(schemas, (sender, e) =>
        {
            Assert.Fail(string.Format("{0}  Severity: {1}", e.Message, e.Severity));
        });
