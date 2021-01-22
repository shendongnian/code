    public static IEnumerable<int> GetAllIndexes(this string source, string matchString)
    {
                List<int> indexes = new List<int>();
                matchString = Regex.Escape(matchString);
                foreach (Match match in Regex.Matches(source, matchString))
                {
                    indexes.Add(match.Index);
                }
                return indexes;
    }
