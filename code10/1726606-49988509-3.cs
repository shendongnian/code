    static DateTimeOffset GetStartOfDay(DateTime dt, TimeZoneInfo tz)
    {
        // Work in the time zone provided
        if (dt.Kind != DateTimeKind.Unspecified)
        {
            dt = TimeZoneInfo.ConvertTime(dt, tz);
        }
        // Start with assuming midnight
        var d = dt.Date;
        // Check for the time being invalid and handle if so
        if (tz.IsInvalidTime(d))
        {
            // the gap is *usually* 1hr, but not always, so calculate it
            var gap = tz.GetUtcOffset(dt.AddDays(1)) - tz.GetUtcOffset(dt.AddDays(-1));
            // advance forward by the amount of the gap
            d = d.Add(gap);
        }
        // Also check for the time being ambiguous, such as in a fall-back transition.
        // We want the *first* occurrence, which will have a *larger* offset
        var offset = tz.IsAmbiguousTime(d)
            ? tz.GetAmbiguousTimeOffsets(d).OrderByDescending(x => x).First()
            : tz.GetUtcOffset(d);
        // Now we know when the date starts precisely
        return new DateTimeOffset(d, offset);
    }
