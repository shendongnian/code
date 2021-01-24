    var manager = new ApplicationPartManager();
    manager.ApplicationParts.Add(new AssemblyPart(typeof(Startup).Assembly));
    manager.ApplicationParts.Add(new AssemblyPart(typeof(Project1.Project1Type).Assembly));
    
    services.AddSingleton(manager);
    services.AddMvc();
