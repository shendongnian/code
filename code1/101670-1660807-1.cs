    public delegate int DynamicDllCall(byte[] b);
    
    public DynamicDllCall CreateDynamicDllInvoke(string functionName, string library)
    {
        // create in-memory assembly, module and type
        AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
            new AssemblyName("DynamicDllInvoke"),
            AssemblyBuilderAccess.Run);
    
        ModuleBuilder modBuilder = assemblyBuilder.DefineDynamicModule("DynamicDllModule");
    
        // note: without TypeBuilder, you can create global functions
        // on the module level, but you cannot create delegates to them
        TypeBuilder typeBuilder = modBuilder.DefineType(
            "DynamicDllInvokeType",
            TypeAttributes.Public | TypeAttributes.UnicodeClass);
    
        // the actual work is done by this method:
        MethodBuilder methodBuilder = typeBuilder.DefinePInvokeMethod(
            functionName,
            library,
            MethodAttributes.Public |
            MethodAttributes.Static |
            MethodAttributes.PinvokeImpl,
            CallingConventions.Standard,
            typeof(int),                     /* the return type */
            new [] {typeof(byte[])},         /* array of parameters, here only one */
            CallingConvention.Winapi,
            CharSet.Ansi);
    
        methodBuilder.SetImplementationFlags(
            methodBuilder.GetMethodImplementationFlags() |
            MethodImplAttributes.PreserveSig);
    
        Type dynamicType = typeBuilder.CreateType();
    
        MethodInfo methodInfo = dynamicType.GetMethod(functionName);
    
        // create a delegate, you can cache these in a Dictionary of some sort
        Delegate delg = Delegate.CreateDelegate(
            typeof(DynamicDllCall),
            methodInfo, true);
    
        return (DynamicDllCall) delg;
    }
    // call this like so:
    DynamicDllCall functionX = CreateDynamicDllInvoke("_function34", "Device01.dll");
    byte b = GetSomeBytes();
    functionX(b);
