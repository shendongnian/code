    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidateType = ValidationType.Schema;
    settings.Schemas.Add("", pathToXsd); // targetNamespace, pathToXsd
    XmlReader reader = XmlReader.Create(pathToXml, settings);
    XmlDocument document = new XmlDocument();
    try {
        document.Load(reader);
    } catch (XmlSchemaValidationException ex) { Trace.WriteLine(ex.Message); }
