    using NodaTime;
    using NodaTime.TimeZones;
    TzdbDateTimeZoneSource.Default.GetIds()
        .Select(x => TzdbDateTimeZoneSource.Default.ForId(x))
        .Where(x => 
            x.GetUtcOffset(SystemClock.Instance.GetCurrentInstant()).ToTimeSpan().TotalMinutes == 330)
