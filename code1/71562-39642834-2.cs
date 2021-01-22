    public static class XmlSerializerFactoryNoThrow
    {
        public static Dictionary<Type, XmlSerializer> _cache = new Dictionary<Type, XmlSerializer>();
        private static object SyncRootCache = new object();        
        /// <summary>
        /// //the constructor XmlSerializer.FromTypes does not throw exception, but it is said that it causes memory leaks
        /// http://stackoverflow.com/questions/1127431/xmlserializer-giving-filenotfoundexception-at-constructor
        /// That is why I use dictionary to cache the serializers my self.
        /// </summary>
        public static XmlSerializer Create(Type type)
        {
            XmlSerializer serializer;
            lock (SyncRootCache)
            {
                if (_cache.TryGetValue(type, out serializer))
                    return serializer;
            }
            lock (type) //multiple variable of type of one type is same instance
            {
                //constructor XmlSerializer.FromTypes does not throw the first chance exception           
                serializer = XmlSerializer.FromTypes(new[] { type })[0];
                //serializer = XmlSerializerFactoryNoThrow.Create(type);
            }
            lock (SyncRootCache)
            {
                _cache[type] = serializer;
            }
            return serializer;
        }       
    }
