    public static void AddRange<T>(this ICollection<T> destination,
                                   IEnumerable<T> source)
    {
        List<T> list = destination as List<T>;
        if (list != null)
        {
            list.AddRange(collection);
        }
        else
        {
            foreach (T item in source)
            {
                destination.Add(item);
            }
        }
    }
