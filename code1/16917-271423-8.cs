    private static readonly Dictionary<Type, XmlSerializer> _serializers = new Dictionary<Type, XmlSerializer>();
    /// <summary>Serializes an object of type T in to an xml string</summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <param name="objectToSerialize">Object to serialize</param>
    /// <returns>A string that represents Xml, empty otherwise</returns>
    public static string XmlSerialize<T>(this T objectToSerialize) where T : class, new()
    {
        if (objectToSerialize == null) throw new ArgumentNullException("objectToSerialize");
        Type type = typeof(T);
        XmlSerializer serializer;
        if (!_serializers.TryGetValue(type, out serializer))
        {
            serializer = new XmlSerializer(type);
            _serializers.Add(type, serializer);
        }
        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, objectToSerialize);
            return writer.ToString();
        }
    }
    /// <summary>Deserializes an xml string in to an object of Type T</summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <param name="xml">Xml as string to deserialize from</param>
    /// <returns>A new object of type T is successful, null if failed</returns>
    public static T XmlDeserialize<T>(this string xml) where T : class, new()
    {
        if (xml == null) throw new ArgumentNullException("xml");
        Type type = typeof(T);
        XmlSerializer serializer;
        if (!_serializers.TryGetValue(type, out serializer))
        {
            serializer = new XmlSerializer(type);
            _serializers.Add(type, serializer);
        }
        using (var reader = new StringReader(xml))
        {
            try { return (T)serializer.Deserialize(reader); }
            catch { return null; } // Could not be deserialized to this type.
        }
    }
