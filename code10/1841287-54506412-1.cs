    var time = DateTime.Now;
    if ((time.DayOfWeek == sunday) && time.Hour > openingTime && closingTime < time.Hour)
    {
        Console.WriteLine(isClosed);
    }
