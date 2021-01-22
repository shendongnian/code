    DateTime startDate = new DateTime(2010, 1, 1);
    DateTime endDate = new DateTime(2011, 12, 12);
    for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
    {
        DayOfWeek dw = date.DayOfWeek;
        // ...
    }
