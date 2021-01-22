    public void ValidateXmlDocument(
        XmlReader documentToValidate, string schemaPath)
    {
        XmlSchema schema;
        using (var schemaReader = XmlReader.Create(schemaPath))
        {
            schema = XmlSchema.Read(schemaReader, ValidationEventHandler);
        }
        var schemas = new XmlSchemaSet();
        schemas.Add(schema);
        var settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        settings.Schemas = schemas;
        settings.ValidationFlags =
            XmlSchemaValidationFlags.ProcessIdentityConstraints |
            XmlSchemaValidationFlags.ReportValidationWarnings;
        settings.ValidationEventHandler += ValidationEventHandler;
        using (var validationReader = XmlReader.Create(documentToValidate, 
               settings))
        {
            while (validationReader.Read()) { }
        }
    }
    private static void ValidationEventHandler(
        object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Error)
        {
            throw args.Exception;
        }
        Debug.WriteLine(args.Message);
    }
