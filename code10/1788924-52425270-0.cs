	var allteams = new List<Team> {
		new Team
		{
			TeamName = "FooBar SO",
			TeamId = 1,
			Matchs = new List<Match>
			{
				new Match{ MatchName="ok" , Season=100 },
				new Match{ MatchName="notOk" , Season=10 }
			}
		},
		new Team
		{
			TeamName = "Other SO",
			TeamId = 2,
			Matchs = new List<Match>
			{
				new Match{ MatchName="nope" , Season=20 },
				new Match{ MatchName="notOk" , Season=10 }
			}
		}
	};
	// All team with at least one match matching the condition
	// The list of match of the team is preserved
	var teamsFilterOnSeason 
		= allteams.Where(t => t.Matchs.Any(m => m.Season >= 100));
		
	
	// All team with at least one match matching the condition
	// The list of match is filter with the condition
	var teamsWithSeasonFilter 
		= allteams
			.Where(t => t.Matchs.Any(m => m.Season >= 100))
			.Select(
				t => 
				new Team {
					TeamName = t.TeamName,
					TeamId = t.TeamId,
					Matchs= t.Matchs
								.Where(m=> m.Season >= 100)
								.ToList()
				}
			);
