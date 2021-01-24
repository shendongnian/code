    public static TestServerWithRepositoryService => new TestServer(services => {
        var mock = new Mock<IGamesByPublisher>();
        var publishers = new List<Publisher>() {
            //...populate as needed
        };
        mock
            .Setup(_ => _.Execute(It.IsAny<GamesByPublisherQueryOptions>()))
            .ReturnsAsync(() => publishers);
        services.RemoveAll<IGamesByPublisher>();
        services.AddScoped<IGamesByPublisher>(sp => mock.Object); 
    }).AddAuthorization("fake.account", null);
