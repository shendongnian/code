    public static string AdjustPath(string filename, string line)
    {
        int tilde = GetTilde(filename);
        
        string[] fields = Regex.Split(line, @"\|");
        
        var addbackslash = new MatchEvaluator(
          m => m.Groups[1].Value + "\\" + m.Groups[2].Value);
        string dir = Regex.Replace(fields[1], @"^([A-Z]:)([^\\])", addbackslash);
  
        var addtilde = new MatchEvaluator(
          m => (tilde + Int32.Parse(m.Groups[1].Value) - 1).
                 ToString().
                 PadLeft(m.Groups[1].Value.Length, '0'));
        return Path.Combine(dir, Regex.Replace(fields[2], @"\{(\d+)-.+}", addtilde));
    }
    private static int GetTilde(string filename)
    {
        Match m = Regex.Match(filename, @"^.+~(\d+)$");
  
        if (!m.Success)
          throw new ArgumentException("Invalid filename", "filename");
        
        return Int32.Parse(m.Groups[1].Value);
    }
