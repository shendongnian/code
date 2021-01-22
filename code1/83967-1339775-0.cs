    public static bool In<T>(this T obj, params T[] candidates)
    {
        return obj.In((IEnumerable<T>)candidates);
    }
    public static bool In<T>(this T obj, IEnumerable<T> candidates)
    {
        if(obj == null) throw new ArgumentNullException("obj");
        return (candidates ?? Enumerable.Empty<T>()).Contains(obj);
    }
