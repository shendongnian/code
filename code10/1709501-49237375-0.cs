    public static IEnumerable<TResult> ZipCycle<TSource1, TSource2, TResult>(
        this IEnumerable<TSource1> first,
        IEnumerable<TSource2> second,
        Func<TSource1, TSource2, TResult> selector)
    {
        if (first == null)
            throw new ArgumentNullException(nameof(first));
        if (second == null)
            throw new ArgumentNullException(nameof(second));
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));
        return InnerZip();
        IEnumerable<TResult> InnerZip()
        {
            using (var f = first.GetEnumerator())
            using (var s = second.GetEnumerator())
            {
                var firstIteration = true;
                while (f.MoveNext())
                {
                    if (!s.MoveNext())
                    {
                        if (firstIteration)
                        {
                            yield break;
                        }
                        else
                        {
                            s.Reset();
                            s.MoveNext();
                        }
                    }
                    yield return selector(f.Current, s.Current);
                    firstIteration = false;
                }
            }
        }
    }
