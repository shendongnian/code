    public static IEnumerable<(Type Class, PropertyInfo Property)> GetAttributeList<T>(Type type)
    {          
       foreach (var prop in type.GetProperties())
       {
          if (prop.GetCustomAttributes(true).OfType<T>().Any())
             yield return (type, prop);
    
          foreach(var result in GetAttributeList<T>(prop.PropertyType))
             yield return (result);
       } 
    }
