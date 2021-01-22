        /// <summary>
        ///     Deserialize XML string, optionally only an inner fragment of the XML, as specified by the innerStartTag parameter.
        /// </summary>
        public static T DeserializeXml<T>(this string @this, string innerStartTag = null) {
            using (var stringReader = new StringReader(@this)) {
                using (var xmlReader = XmlReader.Create(stringReader)) {
                    if (innerStartTag != null) {
                        xmlReader.ReadToDescendant(innerStartTag);
                        var xmlSerializer = CachingXmlSerializerFactory.Create(typeof (T), new XmlRootAttribute(innerStartTag));
                        return (T) xmlSerializer.Deserialize(xmlReader.ReadSubtree());
                    }
                    return (T) CachingXmlSerializerFactory.Create(typeof (T), new XmlRootAttribute("AutochartistAPI")).Deserialize(xmlReader);
                }
            }
        }
    /// <summary>
    ///     A caching factory to avoid memory leaks in the XmlSerializer class.
    /// See http://dotnetcodebox.blogspot.dk/2013/01/xmlserializer-class-may-result-in.html
    /// </summary>
    public static class CachingXmlSerializerFactory {
        private static readonly ConcurrentDictionary<string, XmlSerializer> Cache = new ConcurrentDictionary<string, XmlSerializer>();
        public static XmlSerializer Create(Type type, XmlRootAttribute root) {
            if (type == null) {
                throw new ArgumentNullException(nameof(type));
            }
            if (root == null) {
                throw new ArgumentNullException(nameof(root));
            }
            var key = string.Format(CultureInfo.InvariantCulture, "{0}:{1}", type, root.ElementName);
            return Cache.GetOrAdd(key, _ => new XmlSerializer(type, root));
        }
        public static XmlSerializer Create<T>(XmlRootAttribute root) {
            return Create(typeof (T), root);
        }
        public static XmlSerializer Create<T>() {
            return Create(typeof (T));
        }
        public static XmlSerializer Create<T>(string defaultNamespace) {
            return Create(typeof (T), defaultNamespace);
        }
        public static XmlSerializer Create(Type type) {
            return new XmlSerializer(type);
        }
        public static XmlSerializer Create(Type type, string defaultNamespace) {
            return new XmlSerializer(type, defaultNamespace);
        }
    }
