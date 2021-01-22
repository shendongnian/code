    public static class StringHelpers
    {
        /// <summary>
        /// Same as String.IsNullOrEmpty except that
        /// it captures the Empty state for whitespace
        /// strings by Trimming first.
        /// </summary>
        public static bool IsNullOrTrimEmpty(this String helper)
        {
            if (helper == null)
                return true;
            else
                return String.Empty == helper.Trim();
        }
        public static int TrimLength(this String helper)
        {
            return helper.Trim().Length;
        }
        /// <summary>
        /// Returns the matched string from the regex pattern. The
        /// groupName is for named group match values in the form (?<name>group).
        /// </summary>
        public static string RegexMatch(this String helper, string pattern, RegexOptions options, string groupName)
        {
            if (groupName.IsNullOrTrimEmpty())
                return Regex.Match(helper, pattern, options).Value;
            else
                return Regex.Match(helper, pattern, options).Groups[groupName].Value;
        }
        public static string RegexMatch(this String helper, string pattern)
        {
            return RegexMatch(helper, pattern, RegexOptions.None, null);
        }
        public static string RegexMatch(this String helper, string pattern, RegexOptions options)
        {
            return RegexMatch(helper, pattern, options, null);
        }
        public static string RegexMatch(this String helper, string pattern, string groupName)
        {
            return RegexMatch(helper, pattern, RegexOptions.None, groupName);
        }
        /// <summary>
        /// Returns true if there is a match from the regex pattern
        /// </summary>
        public static bool IsRegexMatch(this String helper, string pattern, RegexOptions options)
        {
            return helper.RegexMatch(pattern, options).Length > 0;
        }
        public static bool IsRegexMatch(this String helper, string pattern)
        {
            return helper.IsRegexMatch(pattern, RegexOptions.None);
        }
        /// <summary>
        /// Returns a string where matching patterns are replaced by the replacement string.
        /// </summary>
        /// <param name="pattern">The regex pattern for matching the items to be replaced</param>
        /// <param name="replacement">The string to replace matching items</param>
        /// <returns></returns>
        public static string RegexReplace(this String helper, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(helper, pattern, replacement, options);
        }
        public static string RegexReplace(this String helper, string pattern, string replacement)
        {
            return Regex.Replace(helper, pattern, replacement, RegexOptions.None);
        }
    }
