    private string ConvertObjectToXml(Type type, object objectToSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(type);
        StringWriter stringWriter = new StringWriter();
    
        xmlSerializer.Serialize(stringWriter, Convert.ChangeType(objectToSerialize, type));
    
        return stringWriter.ToString();
    }
