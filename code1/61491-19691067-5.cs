    var players = db.SoccerTeams.Where(c => c.Country == "Spain")
                                .SelectMany(c => c.players);
    
    foreach(var player in players)
    {
        Console.WriteLine(player.LastName);
    }
