    using Framework.Controllers;
    // ....
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
        .AddApplicationPart(typeof(FrameworkController1).Assembly)
        .AddApplicationPart(typeof(FrameworkController2).Assembly)
        // ...
        .AddControllersAsServices();
