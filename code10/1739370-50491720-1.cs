    public MyConsumer(Func<IServiceA> serviceAFactory, Func<IServiceB> serviceBFactory)
    {
        _serviceA = serviceAFactory();
        _serviceB = serviceBFactory(_serviceA);
        _serviceB.SetServiceA(_serviceA);
    }
