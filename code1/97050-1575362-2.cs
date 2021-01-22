    foreach (Team team in teams
        .GroupBy(t => t.TeamName)
        .Select(ig => ig.OrderByDescending(t => t.PlayerScore).First()))
    {
        Console.WriteLine(team.TeamName + " " + 
            team.PlayerName + " " + 
            team.PlayerScore);
    }
