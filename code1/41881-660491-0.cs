    private static string SerializeObjectToXmlString<T>(T obj)
    {
        XmlSerializer xmls = new XmlSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = Environment.NewLine;
            settings.ConformanceLevel = ConformanceLevel.Document;
            using (XmlWriter writer = XmlTextWriter.Create(ms, settings))
            {
                xmls.Serialize(writer, obj);
            }
            string xml = Encoding.UTF8.GetString(ms.ToArray());
            return xml;
        }
    }
    private static T DeserializeXmlStringToObject <T>(string xmlString)
    {
        XmlSerializer xmls = new XmlSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
        {
            return (T)xmls.Deserialize(ms);
        }
    }
