    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidateType = ValidationType.Schema;
    settings.Schemas.Add("", pathToXsd); // targetNamespace, pathToXsd
    settings.ValidationEventHandler += new ValidationEventHandler(settings_ValidationEventHandler);
    XmlReader reader = XmlReader.Create(pathToXml, settings);
    while (reader.Read()) { }
    private void settings_ValidationEventHandler(object sender, ValidationEventArgs args)
    {
        // e.Message, e.Severity (warning, error), e.Error
        // or you can access the reader if you have access to it
        // reader.LineNumber, reader.LinePosition.. etc
    }
