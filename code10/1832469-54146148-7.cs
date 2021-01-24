    [Test]
    public void viewPlayers_Returns_One()
    {
        var myController=new MyController(...);
        var resultView=(PartialViewResult)myController.ViewPlayers("SomeName");
        var players= (List<Player>)resultView.Model;
        Assert.That(players, Has.Exactly(1).Items);
    }
