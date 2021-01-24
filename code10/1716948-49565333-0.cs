    var winLoss = _teamService.GetGames()
        .Where(x => x.Result != "Tie").GroupBy(x => x.Result)
        .ToDictionary(e => e.Key, e => e.Count());
    int wins = 0;
    int losses = 0;
    winLoss.TryGetValue("WIN", out wins);
    winLoss.TryGetValue("LOSS", out losses);
