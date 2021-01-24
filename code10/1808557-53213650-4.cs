    // Scan for all profiles in an assembly
    // ... using instance approach:
    var config = new MapperConfiguration(cfg => {
        cfg.AddProfiles(myAssembly);
    });
    // ... or static approach:
    Mapper.Initialize(cfg => cfg.AddProfiles(myAssembly));
    
    // Can also use assembly names:
    Mapper.Initialize(cfg =>
        cfg.AddProfiles(new [] {
            "Foo.UI",
            "Foo.Core"
        });
    );
    
    // Or marker types for assemblies:
    Mapper.Initialize(cfg =>
        cfg.AddProfiles(new [] {
            typeof(HomeController),
            typeof(Entity)
        });
    );
