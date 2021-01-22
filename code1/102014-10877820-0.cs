    public static IEnumerable<T> ServeFirst<T>(this IEnumerable<T> source, 
        Predicate<T> p)
    {
        var list = new List<T>();
    
        foreach (var s in source)
        {
            if (p(s))
                yield return s;
            else
                list.Add(s);
        }
    
        foreach (var s in list)
            yield return s;
    }
