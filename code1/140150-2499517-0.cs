    public DateTime RoundToHours(DateTime input)
    {
       if (input.Minute > 29)
          return new DateTime(input.Year, input.Month, input.Day, input.Hour+1, 0, 0);
       else
          return new DateTime(input.Year, input.Month, input.Day, input.Hour, 0, 0);
    }
