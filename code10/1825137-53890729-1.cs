		var votesPerContestant =
			BallotsToTally
				.SelectMany(x => x.Entries.Select(y => y.ContestantID))
				.GroupBy(x => x)
				.Select(x => new { ContestantID = x.Key, Count = x.Count() })
				.ToDictionary(x => x.ContestantID, x => x.Count);
				
		var votesForContestant2 = votesPerContestant[2];
		
		var contestantsWithNoVotes =
			Enumerable
				.Range(1, thingsToVoteOn)
				.Where(x => !votesPerContestant.ContainsKey(x))
				.ToArray();
