    public static IEnumerable<List<T>> ToClusters(
      this IEnumerable<T> source, Func<T, bool> endOfClusterCriteria)
    {
      var result = List<T>();
      foreach(T item in source)
      {
        result.Add(item);
        if (endOfClusterCriteria(item))
        {
          yield return result;
          result = new List<T>(); 
        }
      }
    }
