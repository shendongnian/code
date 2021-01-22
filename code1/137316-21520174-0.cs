    class Wildcard : Regex
        {
            public Wildcard() { }
            public Wildcard(string pattern) : base(WildcardToRegex(pattern)) { }
            public Wildcard(string pattern, RegexOptions options) : base(WildcardToRegex(pattern), options) { }
            public static string WildcardToRegex(string pattern)
            {
                return "^" + Regex.Escape(pattern).
                Replace("\\*", ".*").
                Replace("\\?", ".") + "$";
            }
        }
