    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve
            += ReflectionOnlyAssemblyResolve;
        var reflectionSystemAssembly = Assembly.ReflectionOnlyLoad(
            "System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
        Type[] systemTypes = reflectionSystemAssembly.GetTypes();
    }
