    var startDate = new DateTime(2018, 1, 1);
    var endDate = new DateTime(2018, 3, 1);
    while ((startDate = startDate.AddMinutes(5)) < endDate)
    {
        if (startDate.Hour < 8 || startDate.Hour > 17 ||
            startDate.DayOfWeek == DayOfWeek.Saturday || 
            startDate.DayOfWeek == DayOfWeek.Sunday)
            continue;
        Console.WriteLine("{0:ddd, MMM dd, yyyy HH:mm}", startDate);
    }
