    public static string XmlEncode(string value)
    {
        System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings 
        {
            ConformanceLevel = System.Xml.ConformanceLevel.Fragment
        };
        StringBuilder builder = new StringBuilder();
        using (var writer = System.Xml.XmlWriter.Create(builder, settings))
        {
            writer.WriteString(value);
        }
        return builder.ToString();
    }
    public static string XmlDecode(string xmlEncodedValue)
    {
        System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings
        {
            ConformanceLevel = System.Xml.ConformanceLevel.Fragment
        };
        using (var stringReader = new System.IO.StringReader(xmlEncodedValue))
        {
            using (var xmlReader = System.Xml.XmlReader.Create(stringReader, settings))
            {
                xmlReader.Read();
                return xmlReader.Value;
            }
        }
    }
