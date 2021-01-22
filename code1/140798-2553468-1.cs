    public void VerifyXmlFile(string path)
    {
        // configure the xmlreader validation to use inline schema.
        XmlReaderSettings config = new XmlReaderSettings();
        config.ValidationType = ValidationType.Schema;
        config.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
        config.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
        config.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
        config.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        // Get the XmlReader object with the configured settings.
        XmlReader reader = XmlReader.Create(path, config);
        // Parsing the file will cause the validation to occur.
        while (reader.Read()) ;
    }
    private void ValidationCallBack(object sender, ValidationEventArgs vea)
    {
        if (vea.Severity == XmlSeverityType.Warning)
            Console.WriteLine(
                "\tWarning: Matching schema not found.  No validation occurred. {0}",
                vea.Message);
        else
            Console.WriteLine("\tValidation error: {0}", vea.Message);
    }
