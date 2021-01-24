	void Test()
	{
	    var dateStrings = new string[] {
		    "Mer 15/06","Jeu 16/06","Ven 17/06","Sam 18/06","Dim 19/06","Lun 20/06","Mar 21/06",
		    "Jeu 23/06","Ven 24/06","Sam 25/06","Dim 26/06","Lun 27/06","Mar 28/06","Mer 29/06",
		    "Jeu 30/06","Ven 01/07","Sam 02/07","Dim 03/07","Lun 04/07","Mar 05/07","Mer 06/07"
		    };
			
		var parsedDates = ParseDateStrings(dateStrings);
		foreach (var date in parsedDates)
			Console.WriteLine(date);
	}
	
	// Takes a set of date strings in the format described by the question and returns
	// the analogous set of DateTime objects. This method assumes that the supplied
	// dates are in chronological order.
	List<DateTime> ParseDateStrings(IEnumerable<string> dateStrings)
	{
		var year = DateTime.Today.Year;
		var parsedDates = new List<DateTime>();
		
		// Since we can't know at first how many years are represented in the given
		// data set, we can't really make any assumptions about the year in which the
		// data begins. Instead we assume that the most recent date occurs in either
		// the current year or the latest previous year in which that date was valid,
		// and work through the set backwards.
		foreach (var dateString in dateStrings.Reverse())
		{
			var dayOfWeek = GetDayOfWeek(dateString.Substring(0, 3));
			var day = int.Parse(dateString.Substring(4, 2));
			var month = int.Parse(dateString.Substring(7, 2));
			year = GetMostRecentValidYear(year, month, day, dayOfWeek);
			parsedDates.Add(new DateTime(year, month, day));
		}
		
		// Reversing our output again at this point puts the results back into the
		// same order as the inputs.
		parsedDates.Reverse();
		return parsedDates;
	}
	
	// Gets the appropriate DayOfWeek value for the given three-character abbreviation.
	DayOfWeek GetDayOfWeek(string abbreviation)
	{
		switch (abbreviation.ToLower())
		{
			case "dim": return DayOfWeek.Sunday;
			case "lun": return DayOfWeek.Monday;
			case "mar": return DayOfWeek.Tuesday;
			case "mer": return DayOfWeek.Wednesday;
			case "jeu": return DayOfWeek.Thursday;
			case "ven": return DayOfWeek.Friday;
			case "sam": return DayOfWeek.Saturday;
			default: throw new ArgumentException();
		}
	}
	
	// Gets the latest year that is equal to or earlier than the given year, and in
	// which the given day of the given month fell on the given day of the week.
	int GetMostRecentValidYear(int year, int month, int day, DayOfWeek dayOfWeek)
	{
		while (!YearIsValid(year, month, day, dayOfWeek))
			--year;
			
		return year;
	}
	
	// Returns a flag indicating whether the given day of the given month fell on the
	// given day of the week in the given year.
	bool YearIsValid(int year, int month, int day, DayOfWeek dayOfWeek) =>
		new DateTime(year, month, day).DayOfWeek == dayOfWeek;
