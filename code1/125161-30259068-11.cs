    public static int MinOrDefault(this IEnumerable<int> source, int defaultValue)
    {
      using(var en = source.GetEnumerator())
        if(en.MoveNext())
        {
          var currentMin = en.Current;
          while(en.MoveNext())
          {
            var current = en.Current;
            if(current < currentMin)
              currentMin = current;
          }
          return currentMin;
        }
      return defaultValue;
    }
    public static int MinOrDefault(this IEnumerable<int> source)
    {
      return source.MinOrDefault(0);
    }
    public static int MinOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue)
    {
      return source.Select(selector).MinOrDefault(defaultValue);
    }
    public static int MinOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      return source.Select(selector).MinOrDefault();
    }
