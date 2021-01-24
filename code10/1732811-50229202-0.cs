    public static class TypedSessionValuesExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            var json = JsonConvert.SerializeObject(value,
                new JsonSerializerSettings {
                    PreserveReferencesHandling = PreserveReferencesHandling.All
                });
            var bytes = Encoding.UTF8.GetBytes(json);
            session.Set(key, bytes);
        }
        public static bool TryGetValue<T>(this ISession session, string key, out T value)
        {
            byte[] bytes;
            if (!session.TryGetValue(key, out bytes))
            {
                value = default(T);
                return false;
            }
            try
            {
                var json = Encoding.UTF8.GetString(bytes);
                value = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
    }
