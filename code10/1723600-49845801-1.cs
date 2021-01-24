    services
        .AddMvc()  // registers MVC in IoC and gets you the IMvcBuilder
        .AddRazorPagesOptions(options => 
    {
        options.RootDirectory = "....";
        options.Conventions.Add(new FooConvention....);
        ...
    });
