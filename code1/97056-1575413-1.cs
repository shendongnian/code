    var query = from player in players
                group player by player.TeamName into team
                select team.MaxBy(p => p.PlayerScore);
    foreach (Player player in query)
    {
        Console.WriteLine("{0}: {1} ({2})",
            player.TeamName,
            player.PlayerName,
            player.PlayerScore);
    }
