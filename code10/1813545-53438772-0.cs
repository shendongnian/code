    [Test]
    public void FootBallPlayer_CheckingIfControllerReturnsCorrectView_MustReturnTrue()
    {
        string expected = "CreatePlayer";
        var mock = new Mock<FootballContext>();
        FootballplayerController controller = new FootballPlayerController(mock.Object);
        var result = controller.CreateIngredient() as ViewResult;
        Assert.AreEqual(expected, result.ViewName);
    }
