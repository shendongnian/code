    var webHost = CreateWebHostBuilder(args).Build();
    using (var scope = webHost.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<MyDataContext>();
        // create the database, add some data, etc.
        db.Database.EnsureCreated();
    }
    webHost.Run();
