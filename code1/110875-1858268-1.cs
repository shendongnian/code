    public static class Test
    {
        public static void AssertEqual<TSource, TValue>(
            this TSource source,
            Expression<Func<TSource, TValue>> selector,
            TValue expected)
            where TSource : class
        {
            TValue value = selector.Compile()(source);
            string paramName = selector.Parameters[0].Name;
    
            System.Diagnostics.Debug.Assert(
                EqualityComparer<TValue>.Default.Equals(value, expected),
                typeof(TSource) + " " + paramName + ": " +
                    value + " doesn't match expected " + expected);
        }
    }
