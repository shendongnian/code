    DefaultContractResolver contractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    };
    services
        .AddMvcCore()
        .AddJsonOptions(options => {
            options.SerializerSettings.ContractResolver = contractResolver;
        });
