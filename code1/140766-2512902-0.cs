    // splitting time up into hour intervals
    fooList.GroupBy(f => f.Time.Date.AddHours(f.Time.Hour))
    // splitting time up into day intervals
    fooList.GroupBy(f => f.Time.Date)
    // splitting time up into month intervals
    fooList.GroupBy(f => f.Time.Date.AddDays(-f.Time.Day))
