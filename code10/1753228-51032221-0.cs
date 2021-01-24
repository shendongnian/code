    _testServer = TestServerFactory.CreateServer<TestsStartup>();
    // create service scope and retrieve database context
    using (var scope = _testServer.Host.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetService<AppDbContext>();
        // ensure that the db is created for example
        await db.Database.EnsureCreatedAsync();
        // add test fixtures or whatever
    }
