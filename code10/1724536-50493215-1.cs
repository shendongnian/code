    [Fact]
	public async Task ShouldMostLikelyWork()
	{
		var lifetimeScope = new Mock<ILifetimeScope>();
		lifetimeScope.Setup(x => x.Resolve<IServerAbc>()).Returns(new MockService());
		Functions.LifetimeScope = new Lazy<ILifetimeScope>(() => lifetimeScope.Object);
		var functions = new Functions();
		await functions.Handle(Mock.Of<ILambdaContext>())
			.ConfigureAwait(false);
	}
