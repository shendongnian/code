    var session = new Mock<ISessionHelper>();
    var repo = new Mock<IUserRepository>();
    repo.Setup(s => s.FindById(123)).Returns(new User());
    
    var conroller = new DefaultController(session.Object, repo.Object);
    controller.Execute();
