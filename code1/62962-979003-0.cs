    DateTime exampleDate = DateTime.Parse("12/31/2009");
    bool isLastDayOfMonth = (exampleDate.AddDays(1).Month != exampleDate.Month);
    
    if (isLastDayOfMonth)
        Console.WriteLine(exampleDate.AddMonths(1));
    else
        Console.WriteLine(new DateTime(exampleDate.Year, exampleDate.Month, 1).AddMonths(2).AddDays(-1));
