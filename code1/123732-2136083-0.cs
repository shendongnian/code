    public static string Capitalise(string input)
    {
      //non-starting characters (using lamda syntax here):
      string intermediate = Regex.Replace(input, @"(?<=\.\s*)[a-z]", 
        (match) => { return match.Value.ToUpper(); });
      //now the first character
      return Regex.Replace(intermediate, @"^(?<=\s*)[a-z]",
        (match) => { return match.Value.ToUpper(); });
    }
