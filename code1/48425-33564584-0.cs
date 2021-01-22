    public bool ValidateSchema(string xmlPath, string xsdPath)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(xmlPath);
        xml.Schemas.Add(null, xsdPath);
        try
        {
            xml.Validate(null);
        }
        catch (XmlSchemaValidationException)
        {
            return false;
        }
        return true;
    }
