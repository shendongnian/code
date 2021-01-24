    public static class RegexEx
    {
        public static string Replace(this Regex inst, string input, string replacement, Match match)
        {
            replacement = Regex.Replace(replacement, @"(?<!\\)\$(?:(?<Name>\d+)|{(?<Name>\w+)})", m =>
            {
                return match.Groups[m.Groups["Name"].Value].Success ?
                    match.Groups[m.Groups["Name"].Value].Value : m.Value;
            });
            
            return inst.Replace(input, replacement);
        }
    }
