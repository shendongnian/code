    AssemblyBuilder dynamicCollectibleAssembly = AssemblyBuilder.DefineDynamicAssembly(
      new AssemblyName("CollectibleAssembly"),
      AssemblyBuilderAccess.RunAndCollect, 
      Enumerable.Empty<CustomAttributeBuilder>());
    
    Type dynCollAssemType = dynamicCollectibleAssembly.GetType();
    
    try
    {
      Type assemblyBuilderDataType = Assembly.GetAssembly(typeof(AssemblyBuilder))
          .GetType("System.Reflection.Emit.AssemblyBuilderData");
    
      object assemblyBuilderData = dynCollAssemType
        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        .Single(fi => fi.FieldType == assemblyBuilderDataType)
        .GetValue(dynamicCollectibleAssembly);
    
      object assemblyBuilderAccess = assemblyBuilderDataType
        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        .Single(fi => fi.FieldType == typeof(AssemblyBuilderAccess))
        .GetValue(assemblyBuilderData);
    
      Console.WriteLine(assemblyBuilderAccess);
    }
    catch (Exception e)
    {
      throw e;
    }
