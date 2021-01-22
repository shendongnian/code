    AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(
          assemblyName , AssemblyBuilderAccess.Run, assemblyAttributes);
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("ModuleName");
    TypeBuilder typeBuilder = moduleBuilder.DefineType(
          "MyNamespace.TypeName" , TypeAttributes.Public);
    
    typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
    
    // Add a method
    newMethod = typeBuilder.DefineMethod("MethodName" , MethodAttributes.Public);
    
    ILGenerator ilGen = newMethod.GetILGenerator();
    
    // Create IL code for the method
    ilGen.Emit(...);
 
    // ...
    // Create the type itself
    Type newType = typeBuilder.CreateType();
