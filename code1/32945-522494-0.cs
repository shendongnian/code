    static IEnumerable<PropertyInfo> GetNullProperties(object obj)
    {
      // Get the properties and return only the ones where GetValue
      // does not return null.
      return 
        from pi in obj.GetType().GetProperties(
          BindingFlags.Instance | BindingFlags.Public)
        where pi.GetValue(obj, null) != null
        select pi;
    }
