    public static bool IsGenericList(Type type)
    {
      if (!type.IsGenericType)
        return false;
      var genericArguments = type.GetGenericArguments();
      if (genericArguments.Length != 1)
        return false;
    
      var listType = typeof (IList<>).MakeGenericType(genericArguments);
      return listType.IsAssignableFrom(type);
    }
