    var schemaSet = new XmlSchemaSet();
    schemaSet.Add(null, pathToSchema);
    var settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.DTD;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
    settings.Schemas = schemas;
    settings.ConformanceLevel = ConformanceLevel.Document;
    settings.ValidationEventHandler += ValidationHandler;
    using(var fstream = new FileStream(pathToDocument))
    {
        using(var reader = XmlReader.Create(documentStream, settings))
        {
            while(reader.Read())
            {
            }
        }
    }
