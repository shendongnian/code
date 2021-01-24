     var mockService = new Mock<IUserService>();
     var user = new User()
            {
                UserId = 4,
                IsAdmin = true,
                Token = "12983912803981",
                IsLogged = true,
                MessagesSent = null,
                MessagesReceived = null,
                Nickname = "test3",
                Password = "Str0ngP@ssword123",
                UserChannels = null
            };
     mockService.Setup(x=> x.Authenticate(It.IsAny(), It.IsAny())).Returns(user);
