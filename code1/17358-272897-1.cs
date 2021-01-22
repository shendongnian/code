    private string SplitCamelCase(string s) 
    { 
        Regex upperCaseRegex = new Regex(@"[A-Z]{1}[a-z]*"); 
        MatchCollection matches = upperCaseRegex.Matches(s); 
        List<string> words = new List<string>(); 
        foreach (Match match in matches) 
        { 
            words.Add(match.Value); 
        } 
        return String.Join(" ", words.ToArray()); 
    }
