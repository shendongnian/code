    public List<object> GetObjectsOfType<T>()
    {
       foreach (var pair in objs)
       {
          if (pair.Key == typeof(T) || typeof(T).IsAssignableFrom(pair.Key))
          {
             return pair.Value;
          }
       }
    
       return new List<object>();
    }
