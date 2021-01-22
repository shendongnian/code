    // expand this list to contain all your variants
    // this is basically all you need to adjust (!!!)
    public delegate int Function01(byte[] b);
    public delegate int Function02();
    public delegate void Function03();
    public delegate double Function04(int p, byte b, short s);
    
    // TODO: add some typical error handling
    public T CreateDynamicDllInvoke<T>(string functionName, string library)
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
    
        // get params from delegate dynamically (!), trick from Eric Lippert
        MethodInfo delegateMI = typeof(Function02).GetMethod("Invoke");
        Type[] delegateParams = (from param in delegateMI.GetParameters()
                                select param.ParameterType).ToArray();
    
        // automatically create the correct signagure for PInvoke
        MethodBuilder methodBuilder = typeBuilder.DefinePInvokeMethod(
            functionName,
            library,
            MethodAttributes.Public |
            MethodAttributes.Static |
            MethodAttributes.PinvokeImpl,
            CallingConventions.Standard,
            delegateMI.ReturnType,        /* the return type */
            delegateParams,               /* array of parameters from delegate T */
            CallingConvention.Winapi,
            CharSet.Ansi);
    
        // needed according to MSDN
        methodBuilder.SetImplementationFlags(
            methodBuilder.GetMethodImplementationFlags() |
            MethodImplAttributes.PreserveSig);
    
        Type dynamicType = typeBuilder.CreateType();
    
        MethodInfo methodInfo = dynamicType.GetMethod(functionName);
    
        // create the delegate of type T, double casting is necessary
        return (T) (object) Delegate.CreateDelegate(
            typeof(T),
            methodInfo, true);
    }
    // call it as follows, simply use the appropriate delegate and the
    // the rest "just works":
    Function02 getTickCount = CreateDynamicDllInvoke<Function02>
        ("GetTickCount", "kernel32.dll");
    Debug.WriteLine(getTickCount());
