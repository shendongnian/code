    public class FormatRule
    {
        public string Pattern { get; set; }
        public CultureInfo Culture { get; set; }
        public FormatRule(string pattern, CultureInfo culture)
        {
            Pattern = pattern;
            Culture = culture;
        }
    }
