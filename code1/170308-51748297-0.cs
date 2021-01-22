    public static T ParseXml<T>(this string value) where T : class
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        using (var textReader = new StringReader(value))
        {
            return (T) xmlSerializer.Deserialize(textReader);
        }
    }
