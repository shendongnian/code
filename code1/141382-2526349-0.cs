    public static class StringExtensions
    {
        public static string ReplaceMany(this string s, Dictionary<string, string> replacements)
        {
            var sb = new StringBuilder(s);
            foreach (var replacement in replacements)
            {
                sb = sb.Replace(replacement.Key, replacement.Value);
            }
            return sb.ToString();
        }
    }
