    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    services.Configure<ApiBehaviorOptions>(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            ...
        };
    });
