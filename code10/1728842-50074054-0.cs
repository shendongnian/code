                
                // Arrange
                var mockUserSession = new Mock<IUserSession>();
                mockUserSession.Setup(x => x.User).Returns(_savedUser);
                var sut = new LobbyController(FakeSwagCommunication,mockUserSession.Object);
                // Act
                var result = sut.OpretLobby(_lobbyViewModel);
                // Assert
                Assert.IsInstanceOf<RedirectToActionResult>(result);
