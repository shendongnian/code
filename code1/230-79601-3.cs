    static readonly SortedList<double, Func<TimeSpan, string>> offsets = 
       new SortedList<double, Func<TimeSpan, string>>
    {
        { 0.75, _ => "less than a minute" },
        { 1.5, _ => "about a minute" },
        { 45, x => string.Format("{0} minutes", Math.Round(x.TotalMinutes)) },
        { 90, x => "about an hour"},
        { 1440, x => string.Format("about {0} hours", Math.Round(Math.Abs(x.TotalHours)))},
        { 2880, x => "a day"},
        { 43200, x => string.Format("{0} days", Math.Floor(Math.Abs(x.TotalDays)))},
        { 86400, x => "about a month"},
        { 525600, x => string.Format("{0} months", Math.Floor(Math.Abs(x.TotalDays / 30)))},
        { 1051200, x => "about a year"},
        { double.MaxValue, x => string.Format("{0} years", Math.Floor(Math.Abs(x.TotalDays / 365))) }
    };
    
    public static string ToRelativeDate(this DateTime input)
    {
        TimeSpan x = DateTime.Now.Subtract(input);
        double TotalMinutes = x.TotalMinutes;
        string Suffix = " ago";
    
        if (TotalMinutes < 0.0)
        {
            TotalMinutes = Math.Abs(TotalMinutes);
            Suffix = " from now";
        }
    
        return offsets.First(n => TotalMinutes < n.Key).Value(x) + Suffix;
    }
