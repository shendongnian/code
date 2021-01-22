    public static ICollection<T> ChainAdd<T>(this ICollection<T> collection, T item)
    {
      collection.Add(item);
      return collection;
    }
