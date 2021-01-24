	var washes = await db.Washes.ToListAsync();
	var result = (from w in washes
                group w by new {Date = DateTime.ParseExact(w.WashTime, pattern, null).Date}
                into g
                orderby g.Key.Date descending 
                select new DailyAverageModel {
                    Date = g.Key.Date,
                    NoOfWashesPerDate = g.Count()
                }).ToList();
