    public static Type GetBaseTypeGenericArgument(Type type) {
      return type.BaseType.GetGenericArguments()[0];
    }
    
    ...
    GetBaseTypeGenericArgument(typeof(MyClass));
