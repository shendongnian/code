    var ls = Lifestyle.Transient;
    // Create a collection of InstanceProducer instances for IPollingService<T> registrations
    var producers = new InstanceProducer[]
    {
       ls.CreateProducer<IPollingService<TestContext>, PollingService<TestContext>>(container),
       ls.CreateProducer<IPollingService<LiveContext>, PollingService<LiveContext>>(container),
    };
    // Register a decorator that wraps around all IPollingService<T> instances
    container.RegisterDecorator(typeof(IPollingService<>),
        typeof(ContextAwarePollingServiceDecorator<>));
    // Register the IEnumerable<IPollingService> that contains all IPollingService<T> instances
    container.RegisterInstance(producers.Select(p => (IPollingService)p.GetInstance()));
    // Register the composite
    container.Register<IPollingService, CompositePollingService>(Lifestyle.Singleton);
