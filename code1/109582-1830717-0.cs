            [Test]
            public void DummyTest()
            {
                var userList = new List<User>() { new User() { ID = 2, FirstName = "John", LastName = "Peterson" } };
                var sessionMock = new Mock<ISession>();
                var queryMock = new Mock<IQuery>();
                var transactionMock = new Mock<ITransaction>();
    
                sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
                sessionMock.Setup(session => session.CreateQuery("from User")).Returns(queryMock.Object);
                queryMock.Setup(x => x.List<User>()).Returns(userList);
    
                var controller = new UsersController(sessionMock.Object);
                var result = controller.Index() as ViewResult;
                Assert.IsNotNull(result.ViewData);
            }
