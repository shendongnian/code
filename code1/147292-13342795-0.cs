    public static class RegexExtensions
    {
            public static string ReplaceGroup(this Regex regex, string input, string groupName, string replacement)
            {
                return regex.Replace(input, m =>
                {
                    return ReplaceNamedGroup(input, groupName, replacement, m);
                });
            }
    
            private static string ReplaceNamedGroup(string input, string groupName, string replacement, Match m)
            {
                var capt = m.Groups[groupName].Captures.OfType<Capture>().FirstOrDefault();
                if (capt == null)
                    return m.Value;
                var sb = new StringBuilder(input);
                sb.Remove(capt.Index, capt.Length);
                sb.Insert(capt.Index, replacement.Contains(" ") ? "\"" + replacement + "\"" : replacement);
                return sb.ToString();
            }
    }
