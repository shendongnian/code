    public static void Main()
    {
        var week_test = Convert.ToDateTime("05/06/2018");
		var week_test2 = Convert.ToDateTime("05/13/2018");
        List<DateTime> weekList = new List<DateTime>();
		weekList.Add(week_test);
		weekList.Add(week_test2);
		CultureInfo ciCurr = CultureInfo.CurrentCulture;
	  foreach(var week in weekList)
	  {
        int weekNum = ciCurr.Calendar.GetWeekOfYear(week, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday);
        Console.WriteLine(weekNum);
	  }
    }
