            var matchups = new List<TeamMatch>();
            var matchCount = 1; // sets a count
            var currentMatch = new TeamMatch(); // current matchup
            foreach (var team in tournamentList)
            {                
                // Checks if count is an even number.
                if (matchCount % 2 == 0)
                {
                    // If an even number, add teamB to matchup, 
                    // add current matchup to list and create a new matchup.
                    currentMatch.TeamB = team;
                    matchups.Add(currentMatch);
                    currentMatch = new TeamMatch();
                }
                else
                {
                    // If on odd number, add teamA to matchup.
                    currentMatch.TeamA = team;
                }
                matchCount++; 
            }
            if (matchCount % 2 == 1)
            {
                //Odd number of total teams, one team isn't matched.
            } 
            // Here is where you can set the viewdata of the matchups.
