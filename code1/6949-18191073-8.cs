    public static class Enum<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        public static IEnumerable<T> GetValues()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
        public static IEnumerable<string> GetNames()
        {
            return Enum.GetNames(typeof(T));
        }
    }
