    public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source == null)
        {
            throw Error.ArgumentNull(nameof(source));
        }
        if (predicate == null)
        {
            throw Error.ArgumentNull(nameof(predicate));
        }
        using (IEnumerator<TSource> e = source.GetEnumerator())
        {
            while (e.MoveNext())
            {
                TSource result = e.Current;
                if (predicate(result))
                {
                    while (e.MoveNext())
                    {
                        if (predicate(e.Current))
                        {
                            throw Error.MoreThanOneMatch();
                        }
                    }
                    return result;
                }
            }
        }
        throw Error.NoMatch();
    }
