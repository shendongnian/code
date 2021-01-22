    public static IEnumerable<T> MergePreserveOrder<T, TOrder>(
      this IEnumerable<IEnumerable<T>> sources, 
      Func<T, TOrder> orderFunc)  
      where TOrder : IComparable<TOrder> 
    {
      Dictionary<TOrder, List<IEnumerable<T>>> keyedSources =
        sources.Select(source => source.GetEnumerator())
          .Where(e => e.MoveNext())
          .GroupBy(e => orderFunc(e.Current))
          .ToDictionary(g => g.Key, g => g.ToList()); 
      
      while (keyedSources.Any())
      {
         //this is the expensive line
        KeyValuePair<TOrder, List<IEnumerable<T>>> firstPair = keyedSources
          .OrderBy(kvp => kvp.Key).First();
    
        keyedSources.Remove(firstPair.Key);
        foreach(IEnumerable<T> e in firstPair.Value)
        {
          yield return e.Current;
          if (e.MoveNext())
          {
            TOrder newKey = orderFunc(e.Current);
            if (!keyedSources.ContainsKey(newKey))
            {
              keyedSources[newKey] = new List<IEnumerable<T>>() {e};
            }
            else
            {
              keyedSources[newKey].Add(e);
            }
          }
        }
      }
    }
