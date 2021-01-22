    public static class StringExtension
    {
        static readonly Regex re = new Regex(@"\{([^\}]+)\}", RegexOptions.Compiled);
        public static string FormatPlaceholder(this string str, Dictionary<string, string> fields)
        {
            if (fields == null)
                return str;
            return re.Replace(str, delegate(Match match)
            {
                return fields[match.Groups[1].Value];
            });
            
        }
    }
