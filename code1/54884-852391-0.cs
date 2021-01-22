    static class ExtensionMethods
    {
        public static T InitialiseObjectIfNull<T>(this T obj)
            where T : class, new()
        {
            return obj ?? new T();            
        }
    }
