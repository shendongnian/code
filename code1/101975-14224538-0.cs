    public static void AddRange<T>(this ICollection<T> ic, IEnumerable<T> ie)
    {
        foreach (T obj in ie)
        {
            ic.Add(obj);
        }
    }
