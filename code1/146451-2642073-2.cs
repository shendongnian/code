    public static IEnumerable<int> GetAllIndexes(this string source, string matchString)
    {
       matchString = Regex.Escape(matchString);
       foreach (Match match in Regex.Matches(source, matchString))
       {
          yeild match.Index;
       }
       return indexes;
    }
