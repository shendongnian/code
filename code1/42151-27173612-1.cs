    int Year = 2014;
    int Week = 48;
    int DayOfWeek = 4;
    
    DateTime FecIni = new DateTime(Year, 1, 1);
    FecIni = FecIni.AddDays(7 * (Week - 1));
    if ((int)FecIni.DayOfWeek > DayOfWeek)
    {
        while ((int)FecIni.DayOfWeek != DayOfWeek) FecIni = FecIni.AddDays(-1);
    }
    else
    {
        while ((int)FecIni.DayOfWeek != DayOfWeek) FecIni = FecIni.AddDays(1);
    }
