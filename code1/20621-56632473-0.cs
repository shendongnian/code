    var months = Enumerable.Range(1, 12).Select(i => 
		new
		{
			Index = i,
			MonthName = new CultureInfo("en-US").DateTimeFormat.GetAbbreviatedMonthName(i)
		})
		.ToDictionary(x => x.Index, x => x.MonthName);
