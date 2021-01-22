        var assembly = AppDomain.CurrentDomain.GetAssemblies()[0]; // first assembly for demo purposes
    var types = assembly.GetTypes();
    foreach (var type in types)
    {
        var constructors = type.GetConstructors();
    }
