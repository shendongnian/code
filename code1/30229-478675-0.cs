    public static string ToXmlString(Type type, object value)
    {
        StringBuilder sb = new StringBuilder();
        System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sb);
        System.Xml.Serialization.XmlSerializer serial = 
            new System.Xml.Serialization.XmlSerializer(type);
        serial.Serialize(writer, value);
    }
