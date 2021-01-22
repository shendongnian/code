    public Game AddGame(GameEditViewModel gameToSave)
    {
        gameToSave.MyGame.HomeTeam = new Team { Id = gameToSave.HomeTeamId };
        gameToSave.MyGame.AwayTeam = new Team { Id = gameToSave.AwayTeamId };
    
        context.AddToGame(MyGame);
        context.SaveChanges();
    }
