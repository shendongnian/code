    public static class Enum<T>
        where T: struct
    {
        static Enum()
        {
            Trace.Assert(typeof(T).IsEnum);
        }
        public static ReadOnlyCollection<T> Values = ((T[])Enum.GetValues(typeof(T))).ToList().AsReadOnly();
    }
