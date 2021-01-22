    public static DateTime RoundToHours(DateTime input)
    {
	DateTime dt = new DateTime(input.Year, input.Month, input.Day, input.Hour, 0, 0);
	
        if (input.Minute > 29)
          return dt.AddHours(1);
        else
          return dt;
    }
