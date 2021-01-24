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
