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
                lock (SyncRootCache)
                {
                    if (_cache.TryGetValue(type, out serializer))
                        return serializer;
                }
                serializer = XmlSerializer.FromTypes(new[] { type })[0];
                lock (SyncRootCache)
                {
                    _cache[type] = serializer;
                }
            }          
            return serializer;
        }       
    }
