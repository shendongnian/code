    public static class XmlSerializerCache
    {
        private static readonly Dictionary<string, XmlSerializer> cache =
                                new Dictionary<string, XmlSerializer>();
    
        public static XmlSerializer Create(Type type, XmlRootAttribute root)
        {
            var key = String.Format(
                      CultureInfo.InvariantCulture,
                      "{0}:{1}",
                      type,
                      root.ElementName);
    
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, new XmlSerializer(type, root));
            }
    
            return cache[key];
        }
    }
