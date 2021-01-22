    private bool ValidateDocument(string xmlFile, string xsdFile)
    {
        XmlReaderSettings settings = new XmlReaderSettings{ValidationType 
          = ValidationType.Schema};
        settings.Schemas.Add(XmlSchema.Read(XmlReader.Create(xsdFile)));
        XmlReader reader = XmlReader.Create(xmlFile, settings);
    
        try
        {
            while(reader.Read());
            return true;
        }
        catch (XmlException ex) 
        {
            // XmlException indicates a validation error occurred.
            return false;
        }
    }
