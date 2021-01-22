    public static void AddRange<A,B>(
      this ICollection<A> collection, 
      IEnumerable<B> list)
        where B: A
    {
        foreach (var item in list)
        {
            collection.Add(item);
        }
    }
