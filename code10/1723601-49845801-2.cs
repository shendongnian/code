    services
        .AddMvc()  // registers MVC services in IoCC and gets you the IMvcBuilder
        .AddRazorPagesOptions(options => 
    {
        options.RootDirectory = "....";
        options.Conventions.Add(new FooConvention....);
        ...
    });
