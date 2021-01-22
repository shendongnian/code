    public static class XmlSerializerCache {
        private static readonly Dictionary<string, XmlSerializer> cache = new Dictionary<string, XmlSerializer>();
        public static XmlSerializer Get(Type type, XmlRootAttribute root) {
            var key = String.Format("{0}:{1}", type, root.ElementName);
            XmlSerializer ser;
            if (!cache.TryGetValue(key, out ser)) {
                ser = new XmlSerializer(type, root);
                cache.Add(key, ser);
            }
            return ser;
        }
        public static XmlSerializer Get(Type type, string root) {
            return Get(type, new XmlRootAttribute(root));
        }
    }
