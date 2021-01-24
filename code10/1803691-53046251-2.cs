    AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(new 
    AssemblyName("MyAssembly"), AssemblyBuilderAccess.RunAndSave);
    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("ModuleName", "MyAssembly.dll");
    TypeBuilder typeBuilder = moduleBuilder.DefineType("MyNamespace.TypeName", TypeAttributes.Public);
                                
    typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
        
    // Build the method 'public int ReturnTheAnswer() => 42;'.
    MethodBuilder newMethod = typeBuilder.DefineMethod("ReturnTheAnswer", 
    MethodAttributes.Public, typeof(int), new Type[0]);
    ILGenerator ilGen = newMethod.GetILGenerator();
    ilGen.Emit(OpCodes.Ldc_I4_S, 42);
    ilGen.Emit(OpCodes.Ret);
               
    Type newType = typeBuilder.CreateType();
        
    assemblyBuilder.Save("MyAssembly.dll"); // Save the assembly in the programs work directory ('bin\Debug').
    dynamic o = Activator.CreateInstance(newType); // Create an instance of the dynamically created type.
    int r = (int) o.ReturnTheAnswer();
    Debug.Assert(r == 42); // If this doesn't fail, the type has been built correctly, is in fact in the .dll and can be used perfectly fine.
