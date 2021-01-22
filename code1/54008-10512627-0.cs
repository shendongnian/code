    public static string ToReadableAgeString(this TimeSpan span)
    {
        return string.Format("{0:0}", span.Days / 365.25);
    }
    
    public static string ToReadableString(this TimeSpan span)
    { 
        string formatted = string.Format("{0}{1}{2}{3}", 
            span.Days > 0 ? string.Format("{0:0} days, ", span.Days) : string.Empty,
            span.Hours > 0 ? string.Format("{0:0} hours, ", span.Hours) : string.Empty,
            span.Minutes > 0 ? string.Format("{0:0} minutes, ", span.Minutes) : string.Empty,
            span.Seconds > 0 ? string.Format("{0:0} seconds", span.Seconds) : string.Empty);
    
        if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);
    
        return formatted;
    }
