    public static string Pluralize(int n, string unit)
    {
        if (string.IsNullOrEmpty(unit)) return string.Empty;
    
        n = Math.Abs(n); // -1 should be singular, too
    
        return unit + (n == 1 ? string.Empty : "s");
    }
    
    public static string TimeSpanInWords(TimeSpan aTimeSpan)
    {
        List<string> timeStrings = new List<string>();
    
        int[] timeParts = new[] { aTimeSpan.Days, aTimeSpan.Hours, aTimeSpan.Minutes, aTimeSpan.Seconds };
        string[] timeUnits = new[] { "day", "hour", "minute", "second" };
    
        for (int i = 0; i < timeParts.Length; i++)
        {
            if (timeParts[i] > 0)
            {
                timeStrings.Add(string.Format("{0} {1}", timeParts[i], Pluralize(timeParts[i], timeUnits[i])));
            }
        }
    
        return timeStrings.Count != 0 ? string.Join(", ", timeStrings.ToArray()) : "0 seconds";
    }
