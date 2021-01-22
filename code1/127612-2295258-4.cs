    public static IEnumerable<α> Take<α>(this IEnumerator<α> iterator, int count)
    {
        for (var i = 0; i < count && iterator.MoveNext(); i++)
            yield return iterator.Current;
    }
    public static IEnumerable<IEnumerable<α>> Section<α>(this IEnumerator<α> iterator, int length)
    {
        var sct = Enumerable.Empty<α>();
        do
        {
            sct = iterator.Take(length).ToArray();
            if (sct.Any())
                yield return sct;
        }
        while (sct.Any());
    }
