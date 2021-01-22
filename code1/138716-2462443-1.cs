    [TestMethod]
    public void ContainerCanCreate()
    {
        // Fixture setup
        var builder = new ContainerBuilder();
        builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        builder.RegisterSource(new AutoMockingRegistrationSource());
        var container = builder.Build();
        // Exercise system
        var result = container.Resolve<MyClass>();
        // Verify outcome
        Assert.IsNotNull(result);
        // Teardown
    }
