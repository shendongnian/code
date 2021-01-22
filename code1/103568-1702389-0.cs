    public static Dictionary<string, object> GetProperties<T>(this T instance)
       where T : class
    {
      var values = new Dictionary<string, object>();
      var properties =
        instance.GetType().GetProperties(BindingFlags.Public   |
                                         BindingFlags.Instance |
                                         BindingFlags.GetProperty);
      foreach (var property in properties)
      {
        var accessors = property.GetAccessors();
        
        if ((accessors == null) || (accessors.Length == 0))
          continue;
        string key = property.Name;
        object value = property.GetValue(instance, null);
        values.Add(key, value);
      }
      return values;
    }
