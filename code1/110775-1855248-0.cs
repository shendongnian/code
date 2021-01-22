    static bool IsGenericTypeOf(Type genericType, Type someType)
    {   
      if (someType.IsGenericType 
              && genericType == someType.GetGenericTypeDefinition()) return true;
      return someType.BaseType != null 
              && IsGenericTypeOf(genericType, someType.BaseType);
    }
