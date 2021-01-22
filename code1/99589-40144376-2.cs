    public static TimeSpan GetBusinessTimespanBetween(
        DateTime start, DateTime end,
        TimeSpan workdayStartTime, TimeSpan workdayEndTime,
        List<DateTime> holidays = null)
    {
        if (end < start)
            throw new ArgumentException("start datetime must be before end datetime.");
        // Just create an empty list for easier coding.
        if (holidays == null) holidays = new List<DateTime>();
        if (holidays.Where(x => x.TimeOfDay.Ticks > 0).Any())
            throw new ArgumentException("holidays can not have a TimeOfDay, only the Date.");
        var nonWorkDays = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
        var startTime = start.TimeOfDay;
        // If the start time is before the starting hours, set it to the starting hour.
        if (startTime < workdayStartTime) startTime = workdayStartTime;
        var timeBeforeEndOfWorkDay = workdayEndTime - startTime;
        // If it's after the end of the day, then this time lapse doesn't count.
        if (timeBeforeEndOfWorkDay.TotalSeconds < 0) timeBeforeEndOfWorkDay = new TimeSpan();
        // If start is during a non work day, it doesn't count.
        if (nonWorkDays.Contains(start.DayOfWeek)) timeBeforeEndOfWorkDay = new TimeSpan();
        else if (holidays.Contains(start.Date)) timeBeforeEndOfWorkDay = new TimeSpan();
        var endTime = end.TimeOfDay;
        // If the end time is after the ending hours, set it to the ending hour.
        if (endTime > workdayEndTime) endTime = workdayEndTime;
        var timeAfterStartOfWorkDay = endTime - workdayStartTime;
        // If it's before the start of the day, then this time lapse doesn't count.
        if (timeAfterStartOfWorkDay.TotalSeconds < 0) timeAfterStartOfWorkDay = new TimeSpan();
        // If end is during a non work day, it doesn't count.
        if (nonWorkDays.Contains(end.DayOfWeek)) timeAfterStartOfWorkDay = new TimeSpan();
        else if (holidays.Contains(end.Date)) timeAfterStartOfWorkDay = new TimeSpan();
        // Easy scenario if the times are during the day day.
        if (start.Date.CompareTo(end.Date) == 0)
        {
            if (nonWorkDays.Contains(start.DayOfWeek)) return new TimeSpan();
            else if (holidays.Contains(start.Date)) return new TimeSpan();
            return endTime - startTime;
        }
        else
        {
            var timeBetween = end - start;
            var daysBetween = (int)Math.Floor(timeBetween.TotalDays);
            var dailyWorkSeconds = (int)Math.Floor((workdayEndTime - workdayStartTime).TotalSeconds);
            var businessDaysBetween = 0;
            // Now the fun begins with calculating the actual Business days.
            if (daysBetween > 0)
            {
                var nextStartDay = start.AddDays(1).Date;
                var dayBeforeEnd = end.AddDays(-1).Date;
                for (DateTime d = nextStartDay; d <= dayBeforeEnd; d = d.AddDays(1))
                {
                    if (nonWorkDays.Contains(d.DayOfWeek)) continue;
                    else if (holidays.Contains(d.Date)) continue;
                    businessDaysBetween++;
                }
            }
            var dailyWorkSecondsToAdd = dailyWorkSeconds * businessDaysBetween;
            var output = timeBeforeEndOfWorkDay + timeAfterStartOfWorkDay;
            output = output + new TimeSpan(0, 0, dailyWorkSecondsToAdd);
            return output;
        }
    }
