public static IEnumerable<(int Day, T First, T Second)> ListMatches<T>(IList<T> teams)
{
    var matches = new List<(int, T, T)>();
    if (teams == null || teams.Count < 2)
    {
        return matches;
    }
    var restTeams = new List<T>(teams.Skip(1));
    var teamsCount = teams.Count;
    if (teams.Count % 2 != 0)
    {
        restTeams.Add(default);
        teamsCount++;
    }
    for (var day = 0; day < teamsCount - 1; day++)
    {
        if (restTeams[day % restTeams.Count]?.Equals(default) == false)
        {
            matches.Add((day, teams[0], restTeams[day % restTeams.Count]));
        }
        for (var index = 1; index < teamsCount / 2; index++)
        {
            var firstTeam = restTeams[(day + index) % restTeams.Count];
            var secondTeam = restTeams[(day + restTeams.Count - index) % restTeams.Count];
            if (firstTeam?.Equals(default) == false && secondTeam?.Equals(default) == false)
            {
                matches.Add((day, firstTeam, secondTeam));
            }
        }
    }
    return matches;
}
Code to test it:
    foreach (var match in ListMatches(new List<string> { "T1", "T2", "T3", "T4", "T5", "T6" }))
    {
        Console.WriteLine($"{match.Day} => {match.First}-{match.Second}");
    }
Output for 6 teams:
0 => T1-T2
0 => T3-T6
0 => T4-T5
1 => T1-T3
1 => T4-T2
1 => T5-T6
2 => T1-T4
2 => T5-T3
2 => T6-T2
3 => T1-T5
3 => T6-T4
3 => T2-T3
4 => T1-T6
4 => T2-T5
4 => T3-T4
Output for 5 teams:
0 => T1-T2
0 => T4-T5
1 => T1-T3
1 => T4-T2
2 => T1-T4
2 => T5-T3
3 => T1-T5
3 => T2-T3
4 => T2-T5
4 => T3-T4
