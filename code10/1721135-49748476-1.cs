    public static class SerializersCache {
        private static readonly ConcurrentDictionary<Type, Func<Stream, object>> _cache = new ConcurrentDictionary<Type, Func<Stream, object>>();
        public static object Deserialize(Type type, Stream body) {
            var handler = _cache.GetOrAdd(type, (key) => {
                var arg = Expression.Parameter(typeof(Stream), "body");                
                var genericSerializer = typeof(ProtobufSerializer<>).MakeGenericType(key);
                // new ProtobufSerializer<T>();
                var instance = Expression.New(genericSerializer.GetConstructor(new Type[0]));
                // new ProtobufSerializer<T>().Deserialize(body);
                var call = Expression.Call(instance, "Deserialize", new Type[0], arg);
                // body => new ProtobufSerializer<T>().Deserialize(body);
                return Expression.Lambda<Func<Stream, object>>(call, arg).Compile();
            });
            return handler(body);        
        }
    }
