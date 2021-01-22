    var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("TestAssembly"), AssemblyBuilderAccess.RunAndSave);
    var mod = assembly.DefineDynamicModule("TestModule");
    var type = mod.DefineType("TestType");
    var method = type.DefineMethod("Increment", MethodAttributes.Public, typeof(int), Type.EmptyTypes);
    Expression<Func<int, int>> inc = (a) => a + 1; // this is cool
    inc.CompileToMethod(method);
