    public static TSource MinOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
    {
      if(default(TSource) == null) //Nullable type.
      {
        //Note that the jitter generally removes this code completely when `TSource` is not nullable.
        if(defaultValue == null) // `Min` does what we want.
          return source.Min();
        var comparer = Comparer<TSource>.Default;
        using(var en = source.GetEnumerator())
          if(en.MoveNext())
          {
            var currentMin = en.Current;
            while(currentMin == null)
            {
              if(!en.MoveNext())
                return defaultValue;
              currentMin = en.Current;
            }
            while(en.MoveNext())
            {
              var current = en.Current;
              if(current != null && comparer.Compare(current, currentMin) < 0)
                currentMin = current;
            }
            return currentMin;
          }
      }
      else
      {
        //Note that the jitter generally removes this code completely when `TSource` is nullable.
        var comparer = Comparer<TSource>.Default;
        using(var en = source.GetEnumerator())
          if(en.MoveNext())
          {
            var currentMin = en.Current;
            while(en.MoveNext())
            {
              var current = en.Current;
              if(comparer.Compare(current, currentMin) < 0)
                currentMin = current;
            }
            return currentMin;
          }
      }
      return defaultValue;
    }
