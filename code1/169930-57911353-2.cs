    public static M Cast<T, M>(this IEnumerable<T> input) where M : ICollection<T>, new()
    {
      var ret = new M();
      foreach(var item in input?? Enumerable.Empty<T>())
      {
        ret.Add(item);
      }
      return ret;
    }
