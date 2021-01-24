    var periods = new List<Period>
    {
        new Period {Start = DateTime.Today.AddDays(-1), End = DateTime.Today.AddDays(1)}
    };
    // Use the extension method to see if today's date is in any period
    var todayExists = periods.ContainsDate(DateTime.Today); // returns true
