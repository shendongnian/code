    //Extensions used to stores complex objects as JSON string in session
    public static class SessionExtensions {
        public static void Set(this ISession session, string key, object value) {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    
        public static T Get<T>(this ISession session, string key) {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
