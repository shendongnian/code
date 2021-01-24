    public static partial class XmlNodeExtensions
    {
		public static IEnumerable<T> DeserializeElements<T>(this XmlNode root, string localName, string namespaceUri)
		{
            var serializer = XmlSerializerFactory.Create(typeof(T), localName, namespaceUri);
			var reader = new XmlNodeReader(root);
			while (!reader.EOF)
			{
				if (!(reader.NodeType == XmlNodeType.Element && reader.LocalName == localName && reader.NamespaceURI == namespaceUri))
					reader.ReadToFollowing(localName, namespaceUri);
				
				if (!reader.EOF)
				{
					yield return (T)serializer.Deserialize(reader);
					// Note that the serializer will advance the reader past the end of the node
				}				
			}
		}		
    }
    public static class XmlSerializerFactory
    {
        // To avoid a memory leak the serializer must be cached.
        // https://stackoverflow.com/questions/23897145/memory-leak-using-streamreader-and-xmlserializer
        // This factory taken from 
        // https://stackoverflow.com/questions/34128757/wrap-properties-with-cdata-section-xml-serialization-c-sharp/34138648#34138648
        readonly static Dictionary<Tuple<Type, string, string>, XmlSerializer> cache;
        readonly static object padlock;
        static XmlSerializerFactory()
        {
            padlock = new object();
            cache = new Dictionary<Tuple<Type, string, string>, XmlSerializer>();
        }
        public static XmlSerializer Create(Type serializedType, string rootName, string rootNamespace)
        {
            if (serializedType == null)
                throw new ArgumentNullException();
            if (rootName == null && rootNamespace == null)
                return new XmlSerializer(serializedType);
            lock (padlock)
            {
                XmlSerializer serializer;
                var key = Tuple.Create(serializedType, rootName, rootNamespace);
                if (!cache.TryGetValue(key, out serializer))
                    cache[key] = serializer = new XmlSerializer(serializedType, new XmlRootAttribute { ElementName = rootName, Namespace = rootNamespace });
                return serializer;
            }
        }
    }
