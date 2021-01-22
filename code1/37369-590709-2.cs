    public static T FromXml<T>(T src, string rootName, string fileName) where T : class, new()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));
        TextReader reader = new StreamReader(fileName);
        return serializer.Deserialize(reader) as T;
    }
