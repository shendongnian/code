    var regex = new Regex("<!--X.-->");
    var matches = regex.Matches(teststring);
    var uniqueMatches = matches.Cast<Match>().Distinct(new MatchComparer());
    class MatchComparer : IEqualityComparer<Match>
    {
        public bool Equals(Match a, Match b)
        {
            return a.Value == b.Value;
        }
        public int GetHashCode(Match match)
        {
            return match.Value.GetHashCode();
        }
    }
