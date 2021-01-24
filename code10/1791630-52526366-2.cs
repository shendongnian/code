    //...
    var serviceCollection = new ServiceCollection();
    serviceCollection
        .AddHttpClient(NamedHttpClients.ProxiedClient)
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { 
            Proxy = httpProxy 
        });
        
    var services = serviceCollection.BuildServiceProvider();
    
