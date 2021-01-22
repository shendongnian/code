    public delegate int DynamicDllCall(byte[] b);
    
    public DynamicDllCall CreateDynamicDllInvoke(string functionName, string library)
    {
        AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
            new AssemblyName("DynamicDllInvoke"),
            AssemblyBuilderAccess.Run);
    
        ModuleBuilder modBuilder = assemblyBuilder.DefineDynamicModule("DynamicDllModule");
    
        // note: without TypeBuilder, you can create global functions
        // on the module level, but you cannot create delegates to them
        TypeBuilder typeBuilder = modBuilder.DefineType(
            "DynamicDllInvokeType",
            TypeAttributes.Public | TypeAttributes.UnicodeClass);
    
        MethodBuilder methodBuilder = typeBuilder.DefinePInvokeMethod(
            functionName,
            library,
            MethodAttributes.Public |
            MethodAttributes.Static |
            MethodAttributes.PinvokeImpl,
            CallingConventions.Standard,
            typeof(int),
            new [] {typeof(byte[])},
            CallingConvention.Winapi,
            CharSet.Ansi);
    
        methodBuilder.SetImplementationFlags(
            methodBuilder.GetMethodImplementationFlags() |
            MethodImplAttributes.PreserveSig);
    
        Type dynamicType = typeBuilder.CreateType();
    
        MethodInfo methodInfo = dynamicType.GetMethod(functionName);
    
        Delegate del = Delegate.CreateDelegate(
            typeof(DynamicDllCall),
            methodInfo, true);
    
        return (DynamicDllCall)del;
    }
    // call this like so:
    DynamicDllCall functionX = CreateDynamicDllInvoke("_function34", "Device01.dll");
    byte b = GetSomeBytes();
    functionX(b);
