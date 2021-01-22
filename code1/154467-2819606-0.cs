    public double TimeSpanRoundToQuaterlyHour(DateTime start, DateTime end)
    {
        var timeSpan = end - start;
        int fullHours = (int)timeSpan.TotalHours;
        double fraction = timeSpan.TotalHours - fullHours;
        if (fraction < 0.125 || fraction >= 0.875)
        {
            fraction = 0;
        }
        else if (fraction < 0.375)
        {
            fraction = 0.25;
        }
        else if (fraction < 0.625)
        {
            fraction = 0.5;
        }
        else if (fraction < 0.875)
        {
            fraction = 0.75;
        }
        return fullHours + fraction;
    }
