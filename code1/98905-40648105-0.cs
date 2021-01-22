    // Difference in days, hours, and minutes.
    TimeSpan ts = EndDate - StartDate;
    // Difference in days.
    int differenceInDays = ts.Days; // This is in int
    double differenceInDays= ts.TotalDays; // This is in double
    // Difference in Hours.
    int differenceInHours = ts.Hours; // This is in int
    double differenceInHours= ts.TotalHours; // This is in double
    // Difference in Minutes.
    int differenceInMinutes = ts.Minutes; // This is in int
    double differenceInMinutes= ts.TotalMinutes; // This is in double
