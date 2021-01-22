    public static IEnumerable<IEnumerable<T>> 
        GetSequences<T>(this IEnumerable<T> source, Func<T, bool> selector)
    {
        // omitted null checks for brevity
        var list = new List<T>();
        foreach(var item in source)
        {
            if (selector.Invoke(item))
            {
                list.Add(item);
            }
            else if (list.Count > 0)
            {
                yield return list;
                list = new List<T>();
            }
        }
        if (list.Count > 0)
            yield return list;
    }
