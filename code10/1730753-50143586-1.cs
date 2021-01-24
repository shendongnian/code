    static class Extensions 
    {
      public static T MinBy(this IEnumerable<T> items, Func<T, double> cost) 
      {
        T minItem = default(T);
        double? minCost = null;
        foreach(T item in items) 
        {
          double current = cost(item);
          if (minCost == null || current < minCost)
          {
            minCost = current;
            minItem = item;
          }
        }
        if (minCost == null) throw InvalidOperationException();
        return minItem;
      }
    }
