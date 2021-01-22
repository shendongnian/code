    var types = Assembly.ReflectionOnlyLoad(assemblyName).GetExportedTypes();
    foreach( var t in types )
    {
        bool check = SomeBaseType.IsAssignableFrom(t);
    }
