    public static TimeSpan Round(TimeSpan input)
    {
        if (input < TimeSpan.Zero)
        {
            return -Round(-input);
        }
        int hours = (int) input.TotalHours;
        if (input.Minutes >= 30)
        {
            hours++;
        }
        return TimeSpan.FromHours(hours);
    }
