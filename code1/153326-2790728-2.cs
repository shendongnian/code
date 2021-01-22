    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
        this IEnumerable<TFirst> first,
        IEnumerable<TSecond> second,
        Func<TFirst, TSecond, TResult> resultSelector)
    {
        using (var eFirst = first.GetEnumerator())
        using (eSecond = second.GetEnumerator())
        {
            while (eFirst.MoveNext() && eSecond.MoveNext())
                yield return resultSelector(eFirst.Current, eSecond.Current);
        }
    }
