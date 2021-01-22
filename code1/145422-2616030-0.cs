    var abstractViewModelType = typeof (AbstractViewModel);
    var baseAssembly = Assembly.GetAssembly(abstractViewModelType);
    var modelTypes = baseAssembly.GetTypes()
        .Where(assemblyType => (assemblyType.Namespace != null // Problem if null
                               && assemblyType.Namespace.EndsWith("Models")
                               && assemblyType.Name != "AbstractViewModel"))
        .Select(assemblyType => assemblyType);
    
    foreach(var modelType in modelTypes)
    {
        //Assert some things
    }
