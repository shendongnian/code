    var container = new Container();
    container.Collection.Register(
        typeof(IGlobalExchangeRateLimitProvider),
        new[]
        {
            Lifestyle.Singleton.CreateRegistration<IGlobalExchangeRateLimitProvider>(() => new GlobalExchangeRateLimitProvider("A"), container),
            Lifestyle.Singleton.CreateRegistration<IGlobalExchangeRateLimitProvider>(() => new GlobalExchangeRateLimitProvider("B"), container)
        }
    );
    container.Verify();
