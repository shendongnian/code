    var baseAssembly = Assembly.ReflectionOnlyLoad(typeof(SomeBaseType).Assembly.FullName);
    var baseTypes = baseAssembly.GetExportedTypes();
    var reflectionOnlyBaseType = Array.Find(baseTypes,(t)=>(t.FullName==typeof(SomeBaseType).FullName));
    var types = Assembly.ReflectionOnlyLoad(assemblyName).GetExportedTypes();
    foreach( var t in types )
    {
        bool check = reflectionOnlyBaseType.IsAssignableFrom(t);
    }
