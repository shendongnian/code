    public bool ContainsMyCollection(object obj)
    {
       foreach(var property in obj.GetType().GetProperties())
       {
          //  Idk how to accomplish that
          if(property.PropertyType.IsGenericType 
             && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)
             && typeof(BaseClass).IsAssignableFrom(property.PropertyType.GetGenericArguments()[0]))
          {
              return true;
          }
       }
       return false;
    }
