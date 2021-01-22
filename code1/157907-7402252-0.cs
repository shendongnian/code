    var assemblies = AppDomain.CurrentDomain
        .GetAssemblies()
        .Where(assembly => assembly.GetType().Name == "RuntimeAssembly")
        .Select(assembly => assembly.Location)
        .ToArray();
