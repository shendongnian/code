    class Comparer : IComparer<string> {
        static Regex Matcher = new Regex(@"([^\d]+)(\d+)");
        public int Compare(string x, string y) {
            var xMatch = Matcher.Match(x);
            var yMatch = Matcher.Match(y);
            if (xMatch.Success != yMatch.Success)
                return xMatch.Success ? -1 : 1;
            if (!xMatch.Success)
                return string.Compare(x, y);
            if (xMatch.Groups[1].Value != yMatch.Groups[1].Value)
                return string.Compare(xMatch.Groups[1].Value, yMatch.Groups[1].Value);
            return (int.Parse(xMatch.Groups[2].Value) - int.Parse(yMatch.Groups[2].Value)) < 0 ? -1 : 1;
        }
    }
