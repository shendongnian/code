    public static class DBNullConvert
    {
        public static T To<T>(object value, T defaultValue)
        {
            T cast;
            try
            {
                cast = value == DBNull.Value ? defaultValue : (T)value;
            }
            catch
            {
                throw new ArgumentException(string.Format("Argument of type {0} cannot be cast to type {1}", value.GetType(), typeof(T)), "value");
            }
            return cast;
        }
        public static T To<T>(object value)
        {
            return To(value, default(T));
        }
        public static T? ToNullable<T>(object value) where T : struct
        {
            T? cast;
            try
            {
                cast = value == DBNull.Value ? null : (T?)value;
            }
            catch
            {
                throw new ArgumentException(string.Format("Argument of type {0} cannot be cast to type {1}", value.GetType(), typeof(T?)), "value");
            }
            return cast;
        }
        public static string ToString(object value)
        {
            return To(value, String.Empty);
        }
    }
