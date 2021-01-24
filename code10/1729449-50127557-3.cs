    	[Test]
        public void ShouldReleaseAfterThreeTurns()
    	{
    		// Arrange
    		Mock<ILogger> loggerMock = new Mock<ILogger>();
    		Mock<IDice> diceMock = new Mock<IDice>();
    		diceMock.Setup(s => s.Roll()).Returns(2);
    		Mock<IPlayer> playerMock = new Mock<IPlayer>();
    		playerMock.Setup(s => s.Name).Returns("Adam G");
    		playerMock.Setup(s => s.InJail).Returns(true);
    		playerMock.Setup(s => s.TimeInJail).Returns(3);
    		// Act
    		JailTile jailTile = new JailTile(loggerMock.Object, diceMock.Object);
    		jailTile.LandedOnTile(playerMock.Object);
    		// Assert
    		playerMock.VerifySet(v => v.InJail = false, Times.Once());
    		playerMock.VerifySet(v => v.TimeInJail = 0, Times.Once());
    		loggerMock.Verify(v => v.LogMessage("Adam G has spent 3 turns in jail and is now out"), Times.Once());
    	}
