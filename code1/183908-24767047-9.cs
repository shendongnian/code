    public static class TimeSpanFormatterExtensions
    {
        private static readonly string CustomFormatsRegex = string.Format(@"([^\\])?({0})(?:,{{([^(\\}})]+)}})?", string.Join("|", TimeSpanFormatter.GetRecognizedFormats()));
        public static string ToString(this TimeSpan timeSpan, string format, ICustomFormatter formatter)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException();
            }
            TimeSpanFormatter tsFormatter = (TimeSpanFormatter)formatter;
            format = Regex.Replace(format, CustomFormatsRegex, new MatchEvaluator(m => MatchReplacer(m, timeSpan, tsFormatter)));
            return timeSpan.ToString(format);
        }
        private static string MatchReplacer(Match m, TimeSpan timeSpan, TimeSpanFormatter formatter)
        {
            // the matched non-'\' char before the stuff we actually care about
            string firstChar = m.Groups[1].Success ? m.Groups[1].Value : string.Empty;
            
            string input;
            if (m.Groups[3].Success)
            {
                // has additional formatting
                input = string.Format("{0},{1}", m.Groups[2].Value, m.Groups[3].Value);
            }
            else
            {
                input = m.Groups[2].Value;
            }
            string replacement = formatter.Format(input, timeSpan, formatter);
            if (string.IsNullOrEmpty(replacement))
            {
                return firstChar;
            }
            return string.Format("{0}\\{1}", firstChar, string.Join("\\", replacement.ToCharArray()));
        }
    }
