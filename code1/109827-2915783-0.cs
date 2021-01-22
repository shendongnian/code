    public static class ExtensionMethods
    {
        public static string ToString<T>(this Nullable<T> nullable, string format) where T : struct
        {
            return String.Format("{0:" + format + "}", nullable.GetValueOrDefault());
        }
        public static string ToString<T>(this Nullable<T> nullable, string format, string defaultValue) where T : struct
        {
            if (nullable.HasValue) {
                return String.Format("{0:" + format + "}", nullable.Value);
            }
            return defaultValue;
        }
    }
