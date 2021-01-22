    public static MyHelper
    {
        public static Nullable<T> ToNullable<T>(object value) where T : struct
        {
            if (value == null) return null;
            if (Convert.IsDBNull(value)) return null;
            return (T) value;
        }
        public static string ToString(object value)
        {
            if (value == null) return null;
            if (Convert.IsDBNull(value)) return null;
            return (string)value;
        }
    }
