    private static void ValidateDocument(XmlSchemaSet schemas, string uri)
    {
        var settings = new XmlReaderSettings
                           {
                               Schemas = schemas,
                               ValidationFlags =
                                   XmlSchemaValidationFlags.
                                       ProcessIdentityConstraints |
                                   XmlSchemaValidationFlags.
                                       ReportValidationWarnings,
                               ValidationType = ValidationType.Schema
                           };
        settings.ValidationEventHandler += OnValidationEventHandler;
        using (var validatingReader = XmlReader.Create(uri, settings))
        {
            XDocument.Load(
                validatingReader,
                LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
        }
        return;
    }
