    public static string XmlEncode(string value)
    {
        StringBuilder builder = new StringBuilder();
        System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings 
        {
            ConformanceLevel = System.Xml.ConformanceLevel.Fragment
        };
        using (var writer = System.Xml.XmlWriter.Create(builder, settings))
        {
            writer.WriteString(newValue);
        }
        return builder.ToString();
    }
