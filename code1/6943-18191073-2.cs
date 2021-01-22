    public static class Enum<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        static Enum()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Type " + typeof(T) + " is not a valid enum type.");
        }
        public static IEnumerable<T> Values //a property makes sense
        {
            get { return (T[])Enum.GetValues(typeof(T)); }
        }
    }
