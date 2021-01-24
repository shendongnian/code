    services.AddSingleton<CustomProvider1>();
    services.AddTransient<Controller1>(c => new Controller1(
        c.GetRequiredService<CustomProvider1>()));
    services.AddSingleton<CustomProvider2>();
    services.AddTransient<Controller2>(c => new Controller2(
        c.GetRequiredService<CustomProvider2>()));
