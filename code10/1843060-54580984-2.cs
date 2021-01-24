    services.AddScoped<FooClient>(p =>
    {
        var httpClientFactory = p.GetRequiredService<IHttpClientFactory>();
        var httpContextAccessor = p.GetRequiredService<IHttpContextAccessor>();
        var httpClient = httpClientFactory.Create("ClientName");
        var session = httpContextAccessor.HttpContext.Session;
        var client = new FooClient(httpClient);
        client.SetAuthToken(session["FooAuthToken"]);
    });
