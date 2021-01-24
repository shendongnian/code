    var container = new Container();
    container.Collection.Register<IGlobalExchangeRateLimitProvider>(new[]
        {
            Lifestyle.Singleton.CreateRegistration<IGlobalExchangeRateLimitProvider>(
                () => new GlobalExchangeRateLimitProvider("A"), container),
            Lifestyle.Singleton.CreateRegistration<IGlobalExchangeRateLimitProvider>(
                () => new GlobalExchangeRateLimitProvider("B"), container)
        });
    container.Verify();
