    public static TestServerWithRepositoryService => new TestServer(services => {
        var mock = new Mock<IGamesByPublisher>();        
        mock
            .Setup(_ => _.Execute(It.IsAny<GamesByPublisherQueryOptions>()))
            .Returns(true);
        services.RemoveAll<IGamesByPublisher>();
        services.AddScoped<IGamesByPublisher>(sp => mock.Object); 
    }).AddAuthorization("fake.account", null);
