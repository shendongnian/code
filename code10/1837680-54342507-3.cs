    [TestMethod]
    public void CanCreateTeam()
    {
        //Arrange
        Mock<ITeamRepository> teamRepositoryMock = new Mock<ITeamRepository>();
        Team newTeam = new Team()
        {
            Id = 0,
            Name = "Chicago Bulls",
            Path = "CHI.jpg",
        };
        
        var httpContextMock = new Mock<HttpContextBase>();
        var serverMock = new Mock<HttpServerUtilityBase>();
        serverMock.Setup(x => x.MapPath("~/Images/NBAlogoImg/")).Returns(@"c:\work\app_data");
        httpContextMock.Setup(x => x.Server).Returns(serverMock.Object);
        var fileMock = new Mock<HttpPostedFileBase>();
        fileMock.Setup(x => x.FileName).Returns("file1.pdf");
        
        TeamController controller = new TeamController(teamRepositoryMock.Object);
        controller.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), controller);
        //Act
        ActionResult result = controller.CreateTeam(newTeam , fileMock.Object);
        
        //Assert
        fileMock.Verify(x => x.SaveAs(@"c:\work\app_data\file1.pdf"));
        Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
    }
