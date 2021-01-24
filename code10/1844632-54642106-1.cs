    builder.ConfigureServices((context, services) => {
        var configuration = context.Configuration.
        var myModel = configuration.GetSection("MyModelSection").Get<MyModelClass>();
        
        services.AddSingleton<IMyModelClass, MyModelClass>(myModel);
        services.AddSingleton<IMyServiceClass, MyServiceClass>();
    })
