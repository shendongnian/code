    private class TermAndValue
    {
        public TermAndValue(string singular, string plural, int value)
        {
            Singular = singular;
            Plural = plural;
            Value = value;
        }
        public string Singular { get; }
        public string Plural { get; }
        public int Value { get; }
        public string Term => Value > 1 ? Plural : Singular;
    }
    public static string ToFriendlyDuration(this DateTime value, DateTime? endDate, int maxNrOfElements = 2)
    {
        if (!endDate.HasValue)
            return "Until further notice";
        var extendedTimeSpan = new TimeSpanWithYearAndMonth(value, endDate.Value);
        maxNrOfElements = Math.Max(Math.Min(maxNrOfElements, 5), 1);
        var termsAndValues = new[]
        {
            new TermAndValue("year", "years", extendedTimeSpan.Years),
            new TermAndValue("month", "months", extendedTimeSpan.Months),
            new TermAndValue("day", "days", extendedTimeSpan.Days),
            new TermAndValue("hour", "hours", extendedTimeSpan.Hours),
            new TermAndValue("minute", "minutes", extendedTimeSpan.Minutes)
        };
        
        var parts = termsAndValues.Where(i => i.Value != 0).Take(maxNrOfElements);
        return string.Join(", ", parts.Select(p => $"{p.Value} {p.Term}"));
    }
