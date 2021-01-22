    public static object DeSerializeFromXMLString(System.Type TypeToDeserialize, string xmlString)
    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xmlString);
    MemoryStream mem = new MemoryStream(bytes);			
    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(TypeToDeserialize);
    return ser.Deserialize(mem);
