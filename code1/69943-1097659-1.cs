    public IList<T> GetList<T>(string query) where T : new()
    {
      // whatever you need to distinguish, this is a guess:
      if (typeof(T).IsPrimitiveValue)
      {
        GetPrimitiveList<T>(query);
      }
      else if (typeof(T) == typeof(string))
      {
        GetStringList<T>(query);
      }
      else
      {
        GetEntityList<T>(query);
      }
    
    }
    
    private IList<T> GetStringList<T>(string query)
    
    private IList<T> GetPrimitiveList<T>(string query)
    
    private IList<T> GetEntityList<T>(string query)
