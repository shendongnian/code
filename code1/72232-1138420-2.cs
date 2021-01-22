    private string ConvertObjectToXml(object objectToSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());
        StringWriter stringWriter = new StringWriter();
    
        xmlSerializer.Serialize(stringWriter, objectToSerialize);
    
        return stringWriter.ToString();
    }
