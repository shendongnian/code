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
        return results
            .OrderBy(name => name.Split()[1]) // Order by last name
            .ThenBy(name => name.Split()[0])  // Then by first name
            .ToList();
    }
