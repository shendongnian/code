    public static class IEnumerableExtensions
    {
      public static IEnumerable<IEnumerable<TSource>> Split<TSource>(
                         this IEnumerable<TSource> source, TSource splitter)
      {
        if (source == null)
          throw new ArgumentNullException("source");
        if (splitter == null)
          throw new ArgumentNullException("splitter");
        
        return source.SplitImpl(splitter);
      }
      
      private static IEnumerable<IEnumerable<TSource>> SplitImpl<TSource>(
                         this IEnumerable<TSource> source, TSource splitter)
      {
        var list = new List<TSource>();
        
        foreach (TSource item in source)
        {
          if (!splitter.Equals(item))
          {
            list.Add(item);
          }
          else if (list.Count > 0)
          {
            yield return list.ToList();
            list.Clear();
          }
        }
      }
    }
