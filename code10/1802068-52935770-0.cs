    var teamsEnglandOnlyOver28Years =
        teams
        // Only teams from England
        .Where(t => t.Country == "England")
        // Create a new instance with only the older players
        .Select(t => new Team()
        {
            TeamName = t.TeamName,
            StadiumName = t.StadiumName,
            Players = t.Players.Where(p => p.Age > 28).ToList(),
            Country = t.Country       
        });
