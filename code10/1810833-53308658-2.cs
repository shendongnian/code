    public List<string> GetCombinedParticipants(List<string> players, 
        PlayerContainer allPlayers)
    {
        // Make a copy of the input list
        var results = players.ToList();
        for (int i = 0; i < allPlayers.Count; i++)
        {
            var fullName = $"{allPlayers.FindName(i)} {allPlayers.FindSurname(i)}";
            if (!results.Contains(fullName)) results.Add(fullName);
        }
        // Order by last name, then by first name
        return results
            .OrderBy(name => name.Substring(name.LastIndexOf(" "))) 
            .ThenBy(name => name.Substring(0, name.LastIndexOf(" ") + 1))
            .ToList();
    }
