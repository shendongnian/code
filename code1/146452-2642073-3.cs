    public static IEnumerable<int> GetAllIndexes(this string source, string matchString)
    {
       matchString = Regex.Escape(matchString);
       foreach (Match match in Regex.Matches(source, matchString))
       {
          yield match.Index;
       }
       return indexes;
    }
