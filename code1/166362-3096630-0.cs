    public static Remove<T>(this IList list)
    {
        var toRemove = list.OfType(typeof(T)).ToList();
    
        foreach(var item in toRemove)
            list.Remove(item);
    }
