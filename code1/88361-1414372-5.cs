    public static class Enum<T>
        where T: struct
    {
        static Enum()
        {
            Trace.Assert(typeof(T).IsEnum);
            Values = Array.AsReadOnly((T[])Enum.GetValues(typeof(T)));
        }
        public static readonly ReadOnlyCollection<T> Values;
    }
