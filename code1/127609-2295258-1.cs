    public static IEnumerable<IEnumerable<α>> Section<α>(this IEnumerable<α> source, int length)
    {
        using (var iterator = source.GetEnumerator())
            return iterator.Section(length);
    }
