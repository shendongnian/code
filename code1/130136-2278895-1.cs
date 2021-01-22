    public static int MaxSequence(string str)
    {      
        MatchCollection matches = Regex.Matches(str, "H+|T+");
        return matches.Cast<Match>()
                      .Select(match => match.Value.Length)
                      .OrderByDescending(len => len)
                      .First();
    }
