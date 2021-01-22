    RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
    AssemblyConfigurationEntry myAssembly = new AssemblyConfigurationEntry("strong name for my assembly", "optional path to my assembly");
    rsConfig.Assemblies.Append(myAssembly);
    Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
    myRunSpace.Open();
