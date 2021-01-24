    container.Register(Component.For<IAlfaClient>().ImplementedBy<AlfaClient>()
        .DependsOn(Property.ForKey<IRateLimiter>().Is("RateLimiterAlfa"))
        .LifestyleSingleton());
    container.Register(Component.For<IBetaClient>().ImplementedBy<BetaClient>()
        .DependsOn(Property.ForKey<IRateLimiter>().Is("RateLimiterBeta"))
        .LifestyleSingleton());
    container.Register(Component.For<IRateLimiter>().ImplementedBy<RateLimiter>().LifestyleSingleton().Named("RateLimiterAlfa"));
    container.Register(Component.For<IRateLimiter>().ImplementedBy<RateLimiter>().LifestyleSingleton().Named("RateLimiterBeta"));
