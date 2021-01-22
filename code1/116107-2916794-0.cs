    public static void ValidateXML(Stream stream)
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add("", "yourXSDPath");
        settings.ValidationType = ValidationType.Schema;
        XmlReader reader = XmlReader.Create(stream, settings);
        XmlDocument document = new XmlDocument();
        document.Load(reader);
        ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
        document.Validate(eventHandler);
        reader.Close();
    }
    static void ValidationEventHandler(object sender, ValidationEventArgs e)
    {}
    try
    {
        ValidateXML(yourXMLStream);
    }
    
    catch (XmlSchemaValidationException ex)
    {
        Console.WriteLine(String.Format("Line {0}, position {1}: {2}", ex.Message, ex.LineNumber, ex.LinePosition));
    }
