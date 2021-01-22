    // In your root assembly
    var container = new WindsorContainer();
    container.Install(   
       FromAssembly.This(),
       FromAssembly.InDirectory(new AssemblyFilter("Modules")),
       Configuration.FromAppConfig()
    )
