    private List<Type> GetListOfGenericSerializers()
    {
      Type interfaceGenricType = typeof(ISerializeDeserialize<>);
    
      var serializers =
        from assembly in AppDomain.CurrentDomain.GetAssemblies()
        from genericType in assembly.GetTypes()
        from interfaceType in genericType.GetInterfaces()
        where genericType.IsGenericTypeDefinition &&
              interfaceType.IsGeneric &&
              interfaceType.GetGenericTypeDefinition() == interfaceGenericType
        select genericType;
    
      return serializers.ToList();
    }
