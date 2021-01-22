    public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
    {
        TSource current;
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
        IList<TSource> list = source as IList<TSource>;
        if (list != null)
        {
            return list[index];
        }
        if (index < 0)
        {
            throw Error.ArgumentOutOfRange("index");
        }
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
        Label_0036:
            if (!enumerator.MoveNext())
            {
                throw Error.ArgumentOutOfRange("index");
            }
            if (index == 0)
            {
                current = enumerator.Current;
            }
            else
            {
                index--;
                goto Label_0036;
            }
        }
        return current;
    }
