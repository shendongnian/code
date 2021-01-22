    private static bool TokensMatch(string t1, string t2)
    {
      return TokenString(t1) == TokenString(t2);
    }
    
    private static string TokenString(string input)
    {
      Regex tokenParser = new Regex(@"(\{[0-9]+\})|(\[.*?\])");
    
      string[] tokens = tokenParser.Matches(input).Cast<Match>()
          .Select(m => m.Value).Distinct().OrderBy(s => s).ToArray<string>();
    
      return String.Join(String.Empty, tokens);
    }
