    public static IEnumerable<IEnumerable<T>> Tuples<T>(
        this IEnumerable<T> input,
        int groupCount)
    {
      if (null == input) throw new ArgumentException("input");
      if (groupCount < 1) throw new ArgumentException("groupCount");
    
      var e = input.GetEnumerator();
    
      bool done = false;
      while (!done) {
        var l = new List<T>();
        for (var n = 0; n < groupCount; ++n) {
          if (!e.MoveNext()) {
            if (n != 0) {
              yield return l;
            }
            yield break;
          }
          l.Add(e.Current);
        }
        yield return l;
      }
    }
