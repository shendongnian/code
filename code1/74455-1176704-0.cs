    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>
        (this IEnumerable<TFirst> first, 
        IEnumerable<TSecond> second, 
        Func<TFirst, TSecond, TResult> resultSelector) 
    {
        using (IEnumerator<TFirst> e1 = first.GetEnumerator())
            using (IEnumerator<TSecond> e2 = second.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                    yield return resultSelector(e1.Current, e2.Current);
    }
