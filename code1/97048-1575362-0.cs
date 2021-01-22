    foreach (Team team in teams
        .GroupBy(t => t.TeamName)
        .Select(ig => ig.MaxValue(t => t.PlayerScore)))
    {
        Console.WriteLine(team.TeamName + " " + 
            team.PlayerName + " " + 
            team.PlayerScore);
    }
