    AppDomain appDomain = AppDomain.CurrentDomain;
    
    AssemblyName aname = new AssemblyName ("MyDynamicAssembly");
    
    AssemblyBuilder assemBuilder =
      appDomain.DefineDynamicAssembly (aname, AssemblyBuilderAccess.Run);
    
    ModuleBuilder modBuilder = assemBuilder.DefineDynamicModule ("DynModule");
    
    TypeBuilder tb = modBuilder.DefineType ("Widget", TypeAttributes.Public);
    
    for (int i = 0; i < ushort.MaxValue - 15; i++)
    {
        MethodBuilder methBuilder = tb.DefineMethod ("SayHello" + i, MethodAttributes.Public, null, null);
        ILGenerator gen = methBuilder.GetILGenerator();
        gen.EmitWriteLine ("Hello world");
        gen.Emit (OpCodes.Ret);
    }
    Type t = tb.CreateType();
    object o = Activator.CreateInstance (t);
