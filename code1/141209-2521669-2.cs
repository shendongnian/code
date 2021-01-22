    public static int Count<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
        ICollection<TSource> is2 = source as ICollection<TSource>;
        if (is2 != null)
        {
            return is2.Count;
        }
        ICollection is3 = source as ICollection;
        if (is3 != null)
        {
            return is3.Count;
        }
        int num = 0;
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                num++;
            }
        }
        return num;
    }
