	public void Add(Range rangeToAdd)
	{
		List<Range> mergableRange = new List<Range>();
		foreach (var range in ranges)
		{
			if (rangeToAdd.Start == range.Start && rangeToAdd.End == range.End)
				return; // already exists
			if (mergableRange.Any())
			{
				if (rangeToAdd.End >= range.Start - 1)
				{
					mergableRange.Add(range);
					continue;
				}
			}
			if ((rangeToAdd.Start >= range.Start - 1)
				&& (rangeToAdd.Start <= range.End + 1))
			{
				mergableRange.Add(range);
			}
		}
		if (!mergableRange.Any())//Standalone range
			ranges.Add(rangeToAdd);
		else//merge overlapping ranges
		{
			mergableRange.Add(rangeToAdd);
			var min = mergableRange.Min(x => x.Start);
			var max = mergableRange.Max(x => x.End);
			foreach (var range in mergableRange)
			{
				ranges.Remove(range);
			}
			ranges.Add(new Range(min, max));
		}
		SortAndMerge();
	}
