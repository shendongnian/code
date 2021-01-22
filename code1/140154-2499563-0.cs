    public DateTime RoundToHours(DateTime input)
    {
          DateTime dt = new DateTime(input.Year, input.Month, input.Day, input.Hour, 0, 0);
          return dt.AddHours((int)(input.Minutes / 30));
    }
