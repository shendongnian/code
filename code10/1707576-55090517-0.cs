    [Test or Fact or Whatever]
    public void AllDependenciesPresentAndAccountedFor()
    {
        // Arrange
        var startup = new Startup();
        // Act
        startup.ConfigureServices(serviceCollection);
        // Assert
        var exceptions = new List<InvalidOperationException>();
        var provider = serviceCollection.BuildServiceProvider();
        foreach (var serviceDescriptor in services)
        {
            var serviceType = serviceDescriptor.ServiceType;
            if (serviceType.Namespace.StartsWith("my.namespace.here"))
            {
                try
                {
                    provider.GetService(serviceType);
                }
                catch (InvalidOperationException e)
                {
                    exceptions.Add(e);
                }
            }
        }
        if (exceptions.Any())
        {
            throw new AggregateException("Some services are missing", exceptions);
        }
    }
