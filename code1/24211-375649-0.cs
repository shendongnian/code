    // Set the validation settings.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
    settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
    // Create the XmlReader object.
    XmlReader reader = XmlReader.Create("inlineSchema.xml", settings);
    // Parse the file. 
    while (reader.Read());
