    DateTime current = new DateTime(DateTime.Today.Year, 
        10, DateTime.DaysInMonth(DateTime.Today.Year, 10));
    
    while (current.DayOfWeek != DayOfWeek.Sunday)
    {
        current = current.AddDays(-1);
    }
    
    Console.WriteLine(current.ToLongDateString());
