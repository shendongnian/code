      services.AddHttpClient<TypedClient>()
                          .ConfigureHttpClient((sp, httpClient) =>
                          {
        
                              var options= sp.GetRequiredService<IOptions<SomeOptions>>().Value;
                              httpClient.BaseAddress = platformEndpointOptions.Url;
                              httpClient.Timeout = platformEndpointOptions.RequestTimeout;
                          })
                          .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                          .ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })
                          .AddHttpMessageHandler(sp => sp.GetService<SomeCustomHandler>().CreateAuthHandler())
                          .AddPolicyHandlerFromRegistry(PollyPolicyName.HttpRetry)
                          .AddPolicyHandlerFromRegistry(PollyPolicyName.HttpCircuitBreaker);
    
