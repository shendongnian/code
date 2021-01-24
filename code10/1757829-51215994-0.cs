    var DateList = new List<DateTime>(); // your populated list of dates
    var allDaysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
    var totalDayCounts = allDaysOfWeek.GroupJoin(DateList, dayOfWeek => dayOfWeek, date => date.DayOfWeek, (dayOfWeek, times) => new
    {
        DayOfTheWeek = dayOfWeek,
        DayOfWeekCount = times.Count()
    });
