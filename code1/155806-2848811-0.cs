    DateTime date = new DateTime(year, month, 1);
    int daysBack = Math.Abs(
        date.DayOfWeek - 
        CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
    );
    
    Enumerable.Range(-daysBack, 7)
        .Select(x => date.AddDays(x))
        .ToList()
        .ForEach(d => 
        {
            // a place for html generation
        });
