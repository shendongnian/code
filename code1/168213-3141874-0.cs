    public static IEnumerable<T> ParseAll<T>(this IEnumerable<string> strings, Parser<T> parser)
    {
        foreach (string str in strings)
        {
            T value;
            if (parser(str, out value))
                yield return value;
        }
    }
