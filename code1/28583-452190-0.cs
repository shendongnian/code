    public static class Converter
    {
        public static T Convert<T>(object obj, T defaultValue)
        {
            if (obj != null)
            {
                if (obj is T)
                {
                    return (T)obj;
                }
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter.CanConvertFrom(obj.GetType()))
                {
                    return (T)converter.ConvertFrom(obj);
                }
            }
            return defaultValue;
        }
