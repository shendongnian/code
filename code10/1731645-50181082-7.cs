	var contituencyWithMostVotes = Constituencies
		.Select(c => new
		{
			Contituency = c,
			Candidate = c.Candidates.OrderByDescending(can => can.Votes).First()
		})
		.OrderByDescending(c => c.Candidate.Votes).First();
