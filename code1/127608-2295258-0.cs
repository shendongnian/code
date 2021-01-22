    public static IEnumerable<α> Take<α>(this IEnumerator<α> iterator, int count)
    {
        var i = 0;
        while (i < count && iterator.MoveNext())
            yield return iterator.Current;
    }
    public static IEnumerable<IEnumerable<α>> Section<α>(this IEnumerator<α> iterator, int length)
    {
        var fst = Enumerable.Empty<α>();
        do
        {
            fst = iterator.Take(length);
            yield return fst;
        }
        while (fst.Any());
    }
