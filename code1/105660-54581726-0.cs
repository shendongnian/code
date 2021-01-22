    public static class TypeExtensions
    {
        private static readonly HashSet<Type> NumberTypes = new HashSet<Type>();
        static TypeExtensions()
        {
            NumberTypes.Add(typeof(byte));
            NumberTypes.Add(typeof(decimal));
            NumberTypes.Add(typeof(double));
            NumberTypes.Add(typeof(float));
            NumberTypes.Add(typeof(int));
            NumberTypes.Add(typeof(long));
            NumberTypes.Add(typeof(sbyte));
            NumberTypes.Add(typeof(short));
            NumberTypes.Add(typeof(uint));
            NumberTypes.Add(typeof(ulong));
            NumberTypes.Add(typeof(ushort));
        }
        public static bool IsNumber(this Type type)
        {
            return NumberTypes.Contains(type);
        }
    }
