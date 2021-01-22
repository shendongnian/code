    IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
        if (comparer == null)
        {
            comparer = EqualityComparer<TSource>.Default;
        }
        if (first == null)
        {
            throw Error.ArgumentNull("first");
        }
        if (second == null)
        {
            throw Error.ArgumentNull("second");
        }
        using (IEnumerator<TSource> enumerator = first.GetEnumerator())
        {
            using (IEnumerator<TSource> enumerator2 = second.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (!enumerator2.MoveNext() || !comparer.Equals(enumerator.Current, enumerator2.Current))
                    {
                        return false;
                    }
                }
                if (enumerator2.MoveNext())
                {
                    return false;
                }
            }
        }
        return true;
    }
