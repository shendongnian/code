    /// grab the named httpclient
    var altHttpClient = httpClientFactory.CreateClient("AlternativeAuthInfo");
    /// get the typed client factory from the service provider
    var typedClientFactory = serviceProvider.GetService<ITypedHttpClientFactory<CustomClient>>();
    /// create the typed client
    var altCustomClient = typedClientFactory.CreateClient(altHttpClient);
