        XElement element = null; // Insert the XElement here;
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream("Namespaces.XMLSchema.xsd");
        XmlSchemaSet schemas = new XmlSchemaSet();
        schemas.Add("", XmlReader.Create(stream));
        Boolean error = false;
        element.Validate(element.GetSchemaInfo().SchemaElement, schemas, (sender, e) =>
        {
            Console.WriteLine(e.Message);
            error = true;
        });
