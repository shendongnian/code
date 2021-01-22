    public string[] GetDayNames()
    {
        if (CultureInfo.CurrentCulture.Name.StartsWith("en-"))
        {
            return new [] { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
        }
        else
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
        }
    }
