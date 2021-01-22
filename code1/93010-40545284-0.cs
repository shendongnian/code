    public static bool IsBetween(this DateTime now, TimeSpan start, TimeSpan end)
    {
        var time = now.TimeOfDay;
        // If the start time and the end time is in the same day.
        if (start <= end)
            return time >= start && time <= end;
        // The start time and end time is on different days.
        return time >= start || time <= end;
    }
