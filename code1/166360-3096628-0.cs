    public static IEnumerable<T> Remove<T>(this IEnumerable<T> items, 
                                                Type removeThese)
    {
        return items.Where(i => !removeThese.IsInstanceOfType(i));
    }
    // usage
    mylist.Remove(typeof(int));
