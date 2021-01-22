    DateTime LastYear = DateTime.Now.AddYears(-1)
    DayOfWeek Check = LastYear.DayOfWeek;
    while (Check != DayOfWeek.Monday)
    {
        LastYear = LastYear.addDays(-1);
        Check = LastYear.DayOfWeek;
    }
    Console.WriteLine("{0}",LastYear);
    
