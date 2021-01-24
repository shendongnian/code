    public static IEnumerable<(Type Class, PropertyInfo Property)> GetAttributeList<T>(Type type, HashSet<Type> visited = null)
       where T : Attribute
    {
    
       // keep track of where we have been
       visited = visited ?? new HashSet<Type>();
       // been here before, then bail
       if (!visited.Add(type))
          yield break;
    
       foreach (var prop in type.GetProperties())
       {
          // attribute exists, then yield
          if (prop.GetCustomAttributes<T>(true).Any())
             yield return (type, prop);
    
          // lets recurse the property type as well
          foreach (var result in GetAttributeList<T>(prop.PropertyType, visited))
             yield return (result);
       }
    }
