    public static T GetMiddle<T>(IEnumerable<T> values)
    {
      if (values is IList<T>) return GetMiddle((IList<T>)values);
      if (values is ICollection<T>) return GetMiddle((ICollection<T>)values);
    
      // Use the default implementation here.
    }
    
    private static T GetMiddle<T>(ICollection<T> values)
    {
    }
    
    private static T GetMiddle<T>(IList<T> values)
    {
    }
