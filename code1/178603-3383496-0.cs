    DateTime when = GetDateTimeinPast();
    TimeSpan ts = DateTime.Now.Subtract(when);
    if (ts.TotalHours < 1)
        b.AppendFormat("{0} minutes ago", (int)ts.TotalMinutes);
    else if (ts.TotalDays < 1)
        b.AppendFormat("{0} hours ago", (int)ts.TotalHours);
    //etc...
