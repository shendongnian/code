    var mymock = Mock.Of<IMyClass>();
    Mock.Get(mymock)
        .Setup(m => m.Method1(It.IsAny<string>())
        .Returns(value: whatever);
    var webHostBuilder =
        new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseContentRoot(projectDir)
            .ConfigureTestServices(services => {
                services.TryAddTransient<IMyClass>(sp => mymock);
            })
            .UseStartup<Startup>();
