    private static readonly ConcurrentDictionary<Type, Lazy<XmlSerializer>> TypeSerializers = new ConcurrentDictionary<Type, Lazy<XmlSerializer>>();
    
    public static XmlSerializer GetSerializer(Type type)
    {
        return TypeSerializers.GetOrAdd(type,
        t =>
        {
            var importer = new XmlReflectionImporter();
            var mapping = importer.ImportTypeMapping(t, null, null);
            var lazyResult = new Lazy<XmlSerializer>(() => new XmlSerializer(mapping), LazyThreadSafetyMode.ExecutionAndPublication);
            return lazyResult;
        }).Value;
    }
