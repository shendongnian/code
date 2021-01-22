    public static class Enum<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        //lazily loaded
        static T[] values;
        static string[] names;
        public static IEnumerable<T> GetValues()
        {
            return values ?? (values = (T[])Enum.GetValues(typeof(T)));
        }
        public static IEnumerable<string> GetNames()
        {
            return names ?? (names = Enum.GetNames(typeof(T)));
        }
    }
