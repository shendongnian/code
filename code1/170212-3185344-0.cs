    public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, T item)
    {
       var list = enumerable.ToList();
       list.Add(item);
       return list;
    }
