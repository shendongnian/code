    public static class StringEnumConversion
    {
        public static T Convert<T>(this string str)
        {
            return (T)Enum.Parse(typeof(T), str);
        }
    }
