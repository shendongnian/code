    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
        this IEnumerable<TFirst> first,
        IEnumerable<TSecond> second,
        Func<TFirst, TSecond, TResult> resultSelector)
    {
        using (var firstEnumerator = first.GetEnumerator())
        using (var secondEnumerator = second.GetEnumerator())
        {
            while ((firstEnumerator.MoveNext() && secondEnumerator.MoveNext()))
            {
                yield return resultSelector(firstEnumerator.Current,
                    secondEnumerator.Current);
            }
        }
    }
