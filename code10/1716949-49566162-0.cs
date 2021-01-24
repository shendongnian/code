    var winLoss = _teamService.GetGames()
        .GroupBy(x => x.Team)
        .Where(gg => gg.Key == aTeamName)
        .Select(gg => new 
        { 
            Wins = gg.Count(g => g.Result == "Win"),
            Losses = gg.Count(g => g.Result == "Loss")
        });
