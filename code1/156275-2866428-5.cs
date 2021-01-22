    [TestMethod]
    public void Test_Schema()
    {
        string schemaFileName = @"sampleSchema.xsd";
        string xmlFileName = @"sampleXml.xml";
        XmlSchema schema = 
            XmlSchema.Read(
            File.OpenText(schemaFileName), 
            (o, e) => { throw new Exception("BOOM"); });
        XmlReaderSettings settings = new XmlReaderSettings
        {
            ValidationType = ValidationType.Schema,
            ValidationFlags = 
                XmlSchemaValidationFlags.ProcessInlineSchema | 
                XmlSchemaValidationFlags.ProcessSchemaLocation | 
                XmlSchemaValidationFlags.ReportValidationWarnings | 
                // d'oh! explicit flag for processing identity constraints!
                XmlSchemaValidationFlags.ProcessIdentityConstraints,
        };
        settings.Schemas.Add(schema);
        settings.ValidationEventHandler += 
            (o, e) => { throw new Exception("CRASH"); };
        XmlReader reader = XmlReader.Create(xmlFileName, settings);
        while (reader.Read()) { }
    }
