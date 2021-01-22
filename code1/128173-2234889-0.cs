        DateTime now = DateTime.Now;
        DateTime lastyear = now.AddYears(-1);
        string dayOfWeek = lastyear.DayOfWeek.ToString();
        if (dayOfWeek.Equals("Saturday")) { dayOfWeek = "Friday"; }
        else if (dayOfWeek.Equals("Sunday")) { dayOfWeek = "Monday"; }
        Console.WriteLine(dayOfWeek);
        Console.ReadKey();
