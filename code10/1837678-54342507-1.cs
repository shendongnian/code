    [TestMethod]
    public void CanCreateTeam()
    {
        //Arrange
        Mock<ITeamRepository> teamsMock = new Mock<ITeamRepository>();
        Team newTeam = new Team()
        {
            Id = 0,
            Name = "Chicago Bulls",
            Path = "CHI.jpg",
        };
        byte[] byteBuffer = new Byte[10];
        Random rnd = new Random();
        rnd.NextBytes(byteBuffer);
        System.IO.MemoryStream testStream = new System.IO.MemoryStream(byteBuffer);
        var mockedImageFile = new MockPostedFileBase(testStream, "test/content", "test-file.png");
        
        TeamController controller = new TeamController(teamsMock.Object);
        //Act
        ActionResult result = controller.CreateTeam(newTeam , mockedImageFile);
        teamsMock.Verify(m => m.CreatTeam(newTeam));
        //Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
    }
