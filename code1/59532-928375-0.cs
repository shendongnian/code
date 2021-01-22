    public static IEnumerable<TOutput> ConvertAll<T, TOutput>(this IEnumerable<T> collection, Converter<T, TOutput> converter)
    {
        if (converter == null)
            throw new ArgumentNullException("converter");
    
        List<TOutput> list = new List<TOutput>();
    
        foreach (T item in collection)
        {
            list.Add(converter(item));
        }
    
        return list;
    }
    
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T item in collection)
        {
            action(item);
        }
    }
