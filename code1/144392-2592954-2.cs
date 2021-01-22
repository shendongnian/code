    string input = @"foo ?A&3/3/C)412& bar A341C2";
    string substring = "A41";
    string[] ignoredChars = { "&", "/", "3", "C", ")" };
    
    // builds up the ignored pattern and ensures a dash char is placed at the end to avoid unintended ranges
    string ignoredPattern = String.Concat("[",
                                String.Join("", ignoredChars.Where(c => c != "-")
                                                            .Select(c => Regex.Escape(c)).ToArray()),
                                (ignoredChars.Contains("-") ? "-" : ""),
                                "]*?");
    
    string[] substrings = substring.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
    string pattern = "";
    if (substrings.Length > 1)
    {
        pattern = String.Join(ignoredPattern, substrings);
    }
    else
    {
        pattern = String.Join(ignoredPattern, substring.Select(c => c.ToString()).ToArray());
    }
    
    foreach (Match match in Regex.Matches(input, pattern))
    {
        Console.WriteLine("Index: {0} -- Match: {1}", match.Index, match.Value);
    }
