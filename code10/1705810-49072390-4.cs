	var washes = await db.Washes
	    .GroupBy(w => w.WashTime.Substring(0, 10))
	    .Select(w => new {Date = w.Key, NoOfWashesPerDate = w.Count()})
	    //.OrderByDescending(w => w.Date) // this might or might not be possible depending on the formatting of your date string 
	    .ToListAsync();
	return washes.Select(w => new DailyAverageModel
	{
	    Date = DateTime.ParseExact(w.Date, pattern, null),
	    NoOfWashesPerDate = w.NoOfWashesPerDate
	}).OrderByDescending(w => w.Date).ToList();				
