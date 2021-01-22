    public static IEnumerable<IEnumerable<α>> Section<α>(this IEnumerable<α> source, int length)
    {
        using (var iterator = source.GetEnumerator())
            foreach (var e in iterator.Section(length))
                yield return e;
    }
