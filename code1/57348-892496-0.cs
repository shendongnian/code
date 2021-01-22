    public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
    {
      var map = new Dictionary<A, R>();
      return a =>
        {
          R value;
          if (map.TryGetValue(a, out value))
            return value;
          value = f(a);
          map.Add(a, value);
          return value;
        };
    }
