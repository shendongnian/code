	public Int32[,] GetLineup(Int32 lanes, Int32 racers)
	{
		var rows = new Int32[racers, lanes];
		for (var lane = 0; lane < lanes; lane++)
		{			
			for (var racer = 0; racer < racers; racer++)
			{				
				var taken = Enumerable.Range(0, racer).Select(e => rows[e, lane]).ToList();				
				taken.AddRange(Enumerable.Range(0, lane).Select(e => rows[racer, e]));
				var possible = Enumerable.Range(1, racers);
				var remaining = possible.Except(taken).OrderBy(e => Guid.NewGuid());
				if (!remaining.Any())
				{
					// Failed to get a solution, try again
					return GetLineup(lanes, racers);
				}
				else
				{
					rows[racer, lane] = remaining.First();
				}
			}
		}
		return rows;
	}
