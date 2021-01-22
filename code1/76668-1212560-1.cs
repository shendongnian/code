    public static string SerializeToXml<T>(T value)
    {
        StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(writer, value);
        return writer.ToString();
    }
