    public static IEnumerable<Q> ConsecutivePairs<T, Q>(this IEnumerable<T> sequence, Func<T, T, Q> selector)
    {
        using(var en = sequence.GetEnumerator())
        {
            if (!en.MoveNext()) { yield break; }
            T prev = en.Current;
            while (en.MoveNext())
            {
                yield return selector(prev, en.Current);
                prev = en.Current;
            }
        }
    }
