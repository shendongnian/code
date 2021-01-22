    public static class StringFormat
    {
        static readonly Regex FormatSpecifierRegex = new Regex(@"(?<!\{)\{([0-9]+)[^\}]*?\}(?!\})", RegexOptions.Compiled);
        public static IEnumerable<int> EnumerateArgIndexes(string formatString)
        {
            return FormatSpecifierRegex.Matches(formatString)
             .Cast<Match>()
             .Select(m => int.Parse(m.Groups[1].Value));
        }
        /// <summary>
        /// Finds all the String.Format data specifiers ({0}, {1}, etc.), and returns the
        /// highest index plus one (since they are 0-based).  This lets you know how many data
        /// arguments you need to provide to String.Format in an IEnumerable without getting an
        /// exception - handy if you want to adjust the data at runtime.
        /// </summary>
        /// <param name="formatString"></param>
        /// <returns></returns>
        public static int GetMinimumArgCount(string formatString)
        {
            return EnumerateArgIndexes(formatString).DefaultIfEmpty(-1).Max() + 1;
        }
    }
