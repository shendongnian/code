    private static readonly Dictionary<Type,XmlSerializer> _xmlSerializerCache = new Dictionary<Type, XmlSerializer>();
    public static XmlSerializer CreateDefaultXmlSerializer(Type type) 
    {
        XmlSerializer serializer;
        if (_xmlSerializerCache.TryGetValue(type, out serializer))
        {
            return serializer;
        }
        else
        {
            var importer = new XmlReflectionImporter();
            var mapping = importer.ImportTypeMapping(type, null, null);
            serializer = new XmlSerializer(mapping);
            return _xmlSerializerCache[type] = serializer;
        }
    }
