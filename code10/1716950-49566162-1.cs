    var winLoss = _teamService.GetGames()
        .GroupBy(x => x.Team)
        .Where(gg => gg.Key == "Hello")
        .Select(gg => new 
        { 
            Wins = gg.Count(g => g.Result == "Hello"),
            Losses = gg.Count(g => g.Result != "Hello")
        });
