    public static void Serialize<T>(T instance, string defaultNamespace, Stream stream)
    {
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, defaultNamespace);
        var serializer = new XmlSerializer(typeof(T), defaultNamespace);
        serializer.Serialize(stream, instance, namespaces);
    }
