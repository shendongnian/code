    public void UpdateProperties<T>(this T obj, List<Tuple<string, string>> list) where T : class
    {
       foreach (var tuple in _list)
       {
          var type = obj.GetType();
             var property = type.GetProperty(tuple.Item1, BindingFlags.Public| BindingFlags.NonPublic | BindingFlags.Instance );
          if(property == null)
             continue;
          property.SetValue(obj, tuple.Item2);
       }
    }
