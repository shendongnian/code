    TimeZoneInfo.AdjustmentRule[] adjustmentRules = timeZoneInfo.GetAdjustmentRules();
    TimeZoneInfo.AdjustmentRule adjustmentRule = null;
    if (adjustmentRules.Length > 0)
    {
        // Find the single record that encompasses today's date. If none exists, sets adjustmentRule to null.
        adjustmentRule = adjustmentRules.SingleOrDefault(ar => ar.DateStart <= DateTime.Now && DateTime.Now <= ar.DateEnd);
    }
    
    double bias = -timeZoneInfo.BaseUtcOffset.TotalMinutes; // I'm not sure why this number needs to be negated, but it does.
    string daylightName = timeZoneInfo.DaylightName;
    string standardName = timeZoneInfo.StandardName;
    double daylightBias = adjustmentRule == null ? -60 : -adjustmentRule.DaylightDelta.TotalMinutes; // Not sure why default is -60, or why this number needs to be negated, but it does.
    int daylightDay = 0;
    int daylightDayOfWeek = 0;
    int daylightHour = 0;
    int daylightMonth = 0;
    int standardDay = 0;
    int standardDayOfWeek = 0;
    int standardHour = 0;
    int standardMonth = 0;
    
    if (adjustmentRule != null)
    {
        TimeZoneInfo.TransitionTime daylightTime = adjustmentRule.DaylightTransitionStart;
        TimeZoneInfo.TransitionTime standardTime = adjustmentRule.DaylightTransitionEnd;
    
        // Valid values depend on IsFixedDateRule: http://msdn.microsoft.com/en-us/library/system.timezoneinfo.transitiontime.isfixeddaterule.
        daylightDay = daylightTime.IsFixedDateRule ? daylightTime.Day : daylightTime.Week;
        daylightDayOfWeek = daylightTime.IsFixedDateRule ? -1 : (int)daylightTime.DayOfWeek;
        daylightHour = daylightTime.TimeOfDay.Hour;
        daylightMonth = daylightTime.Month;
    
        standardDay = standardTime.IsFixedDateRule ? standardTime.Day : standardTime.Week;
        standardDayOfWeek = standardTime.IsFixedDateRule ? -1 : (int)standardTime.DayOfWeek;
        standardHour = standardTime.TimeOfDay.Hour;
        standardMonth = standardTime.Month;
    }
