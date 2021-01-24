    var manager = new ApplicationPartManager();
    manager.ApplicationParts.Add(new AssemblyPart(typeof(Startup).Assembly));
  
    services.AddSingleton(manager);
    services.AddMvc();
