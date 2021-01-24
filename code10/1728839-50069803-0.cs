            [Test]
            public void OpretLobby_Post()
            {            
                
                // Arrange
                var mockUserSession = new Mock<IUserSession>();
                mockUserSession.Setup(x => x.User).Returns(_savedUser);
                var sut = new LobbyController(FakeSwagCommunication,mockUserSession.Object);
                // Act
                var result = sut.OpretLobby(_lobbyViewModel) as ViewResult;
                // Assert
                //var user = (User)result.Model;
                Assert.AreEqual("Lobby",result.ViewName);
            }
