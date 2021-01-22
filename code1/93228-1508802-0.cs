    public sealed class RegexHolder
    {
        private readonly string pattern;
        public RegexHolder(string pattern)
        {
            this.pattern = pattern;
        }
        public bool DoesLineMatch(string line, string pattern)
        {
            return Regex.IsMatch(line, pattern);
        }
    }
