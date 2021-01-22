        public static System.Nullable<T> GetValue<T>(this HttpSessionState session, string key) where T : struct, IConvertible
        {
            object value = session[key];
            if (value != null && value is T)
            {
                return (T)value;
            }
            else
                return null;
        }
        public static T GetValue<T>(this HttpSessionState session, string key, T defaultValue) where T : class
        {
            object value = session[key] ?? defaultValue;
            if (value != null && value is T)
            {
                return (T)value;
            }
            else
                return default(T);
        }
