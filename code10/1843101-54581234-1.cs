    var lambda = ActuallyInnerAlsoCompile();
    var dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
        new AssemblyName("dynamicAssembly"),
        AssemblyBuilderAccess.Save);
    var dm = dynamicAssembly.DefineDynamicModule("dynamicModule", "dynamic.dll");
    var dt = dm.DefineType("dynamicType");
    var m1 = dt.DefineMethod(
        "dynamicMethod",
        MethodAttributes.Public | MethodAttributes.Static);
    lambda.CompileToMethod(m1);
    dt.CreateType();
    dynamicAssembly.Save("dynamic.dll");
