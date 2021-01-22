    DateTime date = new DateTime(year, month, 1);
    DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
    int daysBack = (7 + date.DayOfWeek - firstDay) % 7;
    Enumerable.Range(-daysBack, 7)
        .Select(x => date.AddDays(x))
        .ToList()
        .ForEach(d => 
        {
            // a place for html generation
        });
