    protected void PrintDay(int year, int month, DayOfWeek dayName)
    {
      CultureInfo ci = new CultureInfo("en-US");
      for (int i = 1 ; i <= ci.Calendar.GetDaysInMonth (year, month); i++)
      {
        if (new DateTime (year, month, i).DayOfWeek == dayName)
          Response.Write (i.ToString() + "<br/>");
      }
    }
