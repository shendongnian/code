    public static partial class XmlSerializationHelper
    {
        public static T LoadFromXmlAsType<T>(this string xmlString)
        {
            return new StringReader(xmlString).LoadFromXmlAsType<T>();
        }
        public static T LoadFromXmlAsType<T>(this TextReader textReader)
        {
            using (var xmlReader = XmlReader.Create(textReader, new XmlReaderSettings { CloseInput = false }))
                return xmlReader.LoadFromXmlAsType<T>();
        }
        public static T LoadFromXmlAsType<T>(this XmlReader xmlReader)
        {
            while (xmlReader.NodeType != XmlNodeType.Element)
                if (!xmlReader.Read())
                    throw new XmlException("No root element");
            var serializer = XmlSerializerFactory.Create(typeof(T), xmlReader.LocalName, xmlReader.NamespaceURI);
            return (T)serializer.Deserialize(xmlReader);
        }
        public static string SaveToXmlAsType<T>(this T obj, string localName, string namespaceURI)
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
                obj.SaveToXmlAsType(writer, localName, namespaceURI);
            return sb.ToString();
        }
        public static void SaveToXmlAsType<T>(this T obj, TextWriter textWriter, string localName, string namespaceURI)
        {
            using (var xmlWriter = XmlWriter.Create(textWriter, new XmlWriterSettings { CloseOutput = false, Indent = true }))
                obj.SaveToXmlAsType(xmlWriter, localName, namespaceURI);
        }
        public static void SaveToXmlAsType<T>(this T obj, XmlWriter xmlWriter, string localName, string namespaceURI)
        {
            var serializer = XmlSerializerFactory.Create(obj.GetType(), localName, namespaceURI);
            serializer.Serialize(xmlWriter, obj);
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
