    		ListOfConstituencies temp = new ListOfConstituencies();
			var contituencyWithMostVotes = temp.Constituencies
			.Select(c => new
			{
				Constituency = c,
				Candidate = c.Candidates.OrderByDescending(can => can.Votes).First()
			})
			.OrderByDescending(c => c.Candidate.Votes).First();
