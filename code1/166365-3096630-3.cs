    public static void Remove<T>(this IList list)
    {
        var toRemove = list.OfType<T>().ToList();
    
        foreach(var item in toRemove)
            list.Remove(item);
    }
