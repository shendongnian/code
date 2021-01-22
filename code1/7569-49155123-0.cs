    public void AssemblyLoadTest(string assemblyToLoad)
    {
        var initialAppDomainAssemblyCount = AppDomain.CurrentDomain.GetAssemblies().Count(); //4
    
        Assembly.ReflectionOnlyLoad(assemblyToLoad);
        var reflectionOnlyAppDomainAssemblyCount = AppDomain.CurrentDomain.GetAssemblies().Count(); //4
    
        //Shows that assembly is NOT loaded in to AppDomain with Assembly.ReflectionOnlyLoad
        Assert.AreEqual(initialAppDomainAssemblyCount, reflectionOnlyAppDomainAssemblyCount); // 4 == 4
    
        Assembly.Load(assemblyToLoad);
        var loadAppDomainAssemblyCount = AppDomain.CurrentDomain.GetAssemblies().Count(); //5
    
        //Shows that assembly is loaded in to AppDomain with Assembly.Load
        Assert.AreNotEqual(initialAppDomainAssemblyCount, loadAppDomainAssemblyCount); // 4 != 5
    }
