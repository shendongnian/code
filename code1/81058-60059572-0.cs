    public static IEnumerable<(int Day, T First, T Second)> ListMatches<T>(IList<T> teams)
    {
        if (teams.Count % 2 != 0)
        {
            teams.Add(default);
        }
        var restOfTeams = new List<T>(teams.Skip(1));
        var teamsSize = restOfTeams.Count;
        var matches = new List<(int day, T firstTeam, T secondTeam)>();
        for (var day = 0; day < teams.Count - 1; day++)
        {
            if (restOfTeams[day % teamsSize]?.Equals(default) == false)
            {
                matches.Add((day, teams[0], restOfTeams[day % teamsSize]));
            }
            for (var index = 1; index < teams.Count / 2; index++)
            {
                var firstTeam = restOfTeams[(day + index) % teamsSize];
                var secondTeam = restOfTeams[(day + teamsSize - index) % teamsSize];
                if (firstTeam?.Equals(default) == false && secondTeam?.Equals(default) == false)
                {
                    matches.Add((day, firstTeam, secondTeam));
                }
            }
        }
        return matches;
    }
