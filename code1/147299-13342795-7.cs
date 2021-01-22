    public static class RegexExtensions
    {
        public static string Replace(this string input, Regex regex, string groupName, string replacement)
        {
            return regex.Replace(input, m =>
            {
                return ReplaceNamedGroup(input, groupName, replacement, m);
            });
        }
        private static string ReplaceNamedGroup(string input, string groupName, string replacement, Match m)
        {
            string capture = m.Value;
            capture = capture.Remove(m.Groups[groupName].Index - m.Index, m.Groups[groupName].Length);
            capture = capture.Insert(m.Groups[groupName].Index - m.Index, replacement);
            return capture;
        }
    }
