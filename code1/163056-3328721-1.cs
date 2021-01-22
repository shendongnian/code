    var provider = CodeDomProvider.CreateProvider("c#");
    var parameters = new CompilerParameters
    {
    	WarningLevel = 3 // for example, tune how you need
    };
    var result = provider.CompileAssemblyFromSource(parameters, new string[] { "source" });
    if (!result.Errors.HasErrors)
    {
        var assembly = result.CompiledAssembly;
    
        bool containsLocalAppDomain = assembly
            .GetTypes()
            .SelectMany(t => t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            .Any(p => p.Name == "YourProperty");
    
        // indeed it's much better not to load compiled assembly in current appDomain, but create a new one
        var appDomain = AppDomain.CreateDomain("YourNewDomain", null, null);
        bool containsNewAppDomain = appDomain
            .GetAssemblies()
            .SelectMany(a => a
                 .GetTypes()
                 .SelectMany(t => t.GetProperties(BindingFlags.Instance | BindingFlags.Public)))
             .Any(p => p.Name == "YourProperty");
