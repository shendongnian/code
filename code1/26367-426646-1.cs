        static Regex _capitalizedWordPattern = new Regex(@"\b[A-Z][a-z]*\b", RegexOptions.Compiled | RegexOptions.Multiline);
        public static IEnumerable<string> GetDistinctOnlyCapitalizedWords(string text)
        {
            return _capitalizedWordPattern.Matches(text).Cast<Match>().Select(m => m.Value).Distinct();
        }
