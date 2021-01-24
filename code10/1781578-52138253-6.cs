    public Dictionary<int, myCustomType> ActiveTeams; //player #, team
    public void JoinTeam(int playerNumber, string teamColor)
    {
        if (!AvailableTeams.TryGetValue(teamColor, out myCustomType team)
        // handle team already taken.
        ActiveTeams.Add(playerNumber, team);
        AvailableTeams.Remove(teamColor);
    }
