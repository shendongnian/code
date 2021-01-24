    [Test]
    public void TestService()
    {
       var mockRepository = new Mock<IPlayerRepository>();
       mockRepository.Setup(x => x.GetPlayers()).Returns(buildTestPlayerList());
       var serviceUnderTest = new PlayerService { PlayerRepository = mockRepository.Object };
       // continue with test...
    }
