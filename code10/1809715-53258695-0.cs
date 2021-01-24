    public void Configure(IAppBulder app)
    {
        myService.DoSomething();
    }
    public void ConfigureDevelopment(IAppBulder app)
    {
        myService.DoSomething();
    }
    public void ConfigureProduction(IAppBulder app)
    {
        myService.DoSomething();
    }
    public void ConfigureStaging(IAppBulder app)
    {
        myService.DoSomething();
    }
    public void ConfigureSomethingElse(IAppBulder app)
    {
        myService.DoSomething();
    }
