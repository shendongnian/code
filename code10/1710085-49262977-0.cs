    var assembly = typeof(YourClass).Assembly; // I actually use Assembly.LoadFile with well-known names 
    var types = assembly.ExportedTypes
       // filter types that are unrelated
       .Where(x => x.IsClass && x.IsPublic);
    foreach (var type in types)
    {
        // assume that we want to inject any class that implements an interface
        // whose name is the type's name prefixed with I
        services.AddScoped(type.GetInterface($"I{type.Name}"), type);
    }
