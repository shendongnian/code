    public static IEnumerable<IEnumerable<T>>
      Section<T>(this IEnumerable<T> source, int length)
    {
      if (length <= 0)
        throw new ArgumentOutOfRangeException("length");
      var section = new LinkedList<T>();
      foreach (var item in source)
      {
        section.AddLast(item);
        if (section.Count == length)
        {
          yield return section.AsReadOnly();
          section = new LinkedList<T>();
        }
      }
      if (section.Count > 0)
        yield return section.AsReadOnly();
    }
    static IEnumerable<T> AsReadOnly<T>(this IEnumerable<T> source)
    {
      foreach (var item in source)
        yield return item;
    }
  
