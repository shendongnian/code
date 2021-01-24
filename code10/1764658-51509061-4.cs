    protected override void Configure()
    {
        base.Configure();
        _container.Singleton<IEventAggregator, EventAggregator>();
        _container.Singleton<ShellViewModel>();
        _container.PerRequest<OtherViewModel>(); // If you'll only ever have one OtherViewModel then you can set this as a Singleton instead of PerRequest
    }
