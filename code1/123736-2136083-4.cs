    public static string Capitalise(string input)
    {
      //now the first character
      return Regex.Replace(input, @"(?<=(^|[.;:])\s*)[a-z]",
        (match) => { return match.Value.ToUpper(); });
    }
