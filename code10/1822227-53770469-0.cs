    public static DateTime ParseDateWithSanity(this DateTime, string date)
    {
        dt = DateTime.Parse(date);
        if dt.Year < 1900
        {
          throw BadInputException()
        }
    }
