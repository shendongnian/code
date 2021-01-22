    // Notice: extension methods must belong to a class marked static.
    public static class EnumerableParser
    {
        // modified code to prevent horizontal overflow
        public static IEnumerable<T> ParseAll<T>
        (this IEnumerable<string> strings, Parser<T> parser)
        {
            foreach (string str in strings)
            {
                T value;
                if (parser(str, out value))
                    yield return value;
            }
        }
    }
