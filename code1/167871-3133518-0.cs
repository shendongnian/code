    public static string ToXmlString(object xmlObject)
    {
        if (xmlObject == null)
            throw new NullReferenceException("xmlObject cannot be null.");
    
        String xmlResult = null;
    
        XmlSerializer serializer = new XmlSerializer(xmlObject.GetType());
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, xmlObject);
            xmlResult = writer.ToString();
        }
    
        return xmlResult;
    }
