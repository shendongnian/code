    //setup
    var options = new DbContextOptionsBuilder<PlayersContext>()
        .UseInMemoryDatabase(databaseName: "Players Test")
        .Options;
    using(var ctx = new PlayersContext(options))
    {
        ctx.Players.Add(new Player{...});
        ctx.SaveChanges();
    }
    //Execute
    using(var ctx = new PlayersContext(options))
    {
        var myController=new MyController(ctx);
        ...
    }
