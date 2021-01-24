    DateTime StartDate = new DateTime(2018, 2, 12);
    DateTime EndDate = new DateTime(2018, 5, 23);
    
    for (int i = 0; i <= EndDate.Month - StartDate.Month; i++)
    {
        DateTime FirstDay = new DateTime(2018, StartDate.Month + i, 1);
        if (i == 0)
        {
            FirstDay = StartDate;
        }
        DateTime LastDay = new DateTime(2018, StartDate.Month + i, DateTime.DaysInMonth(2018, FirstDay.Month));
        if (i == EndDate.Month - StartDate.Month)
        {
            LastDay = EndDate;
        }
        Console.WriteLine(FirstDay.ToString("d-MMMM") + " to " + LastDay.ToString("d-MMMM"));
    }
                
    Console.ReadLine();
