    public static T CreateType<T>(List<T> list) where T : new ()
    {
       var obj = new T();
    
       var type = typeof(T);
       var properties = type.GetProperties();
    
       foreach (var prop in properties)
       {
          var value = list.Select(x => x.GetType()
                                        .GetProperties()
                                        .First(y => y == prop)
                                        .GetValue(x) as string)
                          .OrderByDescending(x => x.Length)
                          .First();
             
          var propInstance = obj.GetType()
                                .GetProperties()
                                .First(x => x == prop);
    
          propInstance.SetValue(obj, value);
       }
    
       return obj;
    }
