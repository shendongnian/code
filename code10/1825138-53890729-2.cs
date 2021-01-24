		var ballots = BallotsToTally.Select(x => x.Entries.OrderBy(y => y.OrderedPreferenceForContestant).Select(y => y.ContestantID).ToArray()).ToArray();
		var active = Enumerable.Range(1, thingsToVoteOn).ToList();
		var top = (IGrouping<int, int>)null;
		
		while (active.Count() > 0)
		{
			var votes =
				from a in active
				join v in ballots.Select(x => x.Where(y => active.Contains(y)).FirstOrDefault()).Where(x => x != 0) on a equals v into gvs
				select new { candidate = a, votes = gvs.Count() };
			var ranks =
				votes
					.OrderByDescending(x => x.votes)
					.ThenBy(x => x.candidate)
					.GroupBy(x => x.votes, x => x.candidate)
					.ToArray();
			
			top = ranks.First();
			
			Console.WriteLine(String.Join(Environment.NewLine, ranks.Select(x => $"{x.Key} votes for {String.Join(", ", x)}")));
			Console.WriteLine();
			
			foreach (var candidate in ranks.Last())
			{
				active.Remove(candidate);
			}
		}
		
		Console.WriteLine($"Winner(s) {top.Key} votes for {String.Join(", ", top)}");
