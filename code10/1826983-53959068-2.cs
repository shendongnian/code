    public void ConfigureServices(IServiceCollection services) {
        services.AddHttpClient();
        services
            .AddHttpClient<IHttpClientService, HttpClientService>() //<-- TAKE NOTE
            .AddPolicyHandler((service, request) =>
                HttpPolicyExtensions.HandleTransientHttpError()
                    .WaitAndRetryAsync(3,
                        retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)))
            );
    }
    
