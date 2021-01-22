        public void ValidateXmlToXsd(string xsdFilePath, string xmlFilePath)
        {
            XmlSchema schema = ValidateXsd(xsdFilePath);
            XmlDocument xmlData = new XmlDocument();
            XmlReaderSettings validationSettings = new XmlReaderSettings();
            validationSettings.Schemas.Add(schema);
            validationSettings.Schemas.Compile();
            validationSettings.ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema;
            validationSettings.ValidationType = ValidationType.Schema;
            validationSettings.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
            XmlReader xmlFile = XmlReader.Create(xmlFilePath, validationSettings);
            xmlData.Load(xmlFile);
            xmlFile.Close();
        }
        private XmlSchema ValidateXsd(string xsdFilePath)
        {
            StreamReader schemaFile = new StreamReader(xsdFilePath);
            XmlSchema schema = XmlSchema.Read(schemaFile, new ValidationEventHandler(ValidationHandler));
            schema.Compile(new ValidationEventHandler(ValidationHandler));
            schemaFile.Close();
            schemaFile.Dispose();
            return schema;
        }
        private void ValidationHandler(object sender, ValidationEventArgs e)
        {
            throw new XmlSchemaException(e.Message);
        }
