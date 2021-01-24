       private Player aiChoose(Team team)
        {
            return allPlayers.Where(p => p.TeamId == team.Id)  // Get only players from specified team
                             .GroupBy(p => p.Position)         // Group players from that team by position
                             .MinBy(g => g.Count())            // Get players from a position which the team has the smallest count of players at
                             .MaxBy(p => p.Overall);           // Get the best player from that position
        } 
