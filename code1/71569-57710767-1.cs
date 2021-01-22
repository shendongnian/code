    public static class XmlSerializerHelper
    {
        private static readonly ConcurrentDictionary<Type, XmlSerializer> TypeSerializers = new ConcurrentDictionary<Type, XmlSerializer>();
        public static XmlSerializer GetSerializer(Type type)
        {
            return TypeSerializers.GetOrAdd(type,
            t =>
            {
                var importer = new XmlReflectionImporter();
                var mapping = importer.ImportTypeMapping(t, null, null);
                return new XmlSerializer(mapping);
            });
        }
    }
