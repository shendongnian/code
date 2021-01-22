    string input = @"Managers Alice, Bob, Charlie
    Supervisors Don, Edward, Francis";
    string pattern = @"(?<Title>\w+)\s+(?:(?<Names>\w+)(?:,\s*)?)+";
    
    foreach (Match m in Regex.Matches(input, pattern))
    {
        Console.WriteLine("Title: {0}", m.Groups["Title"].Value);
        foreach (Capture c in m.Groups["Names"].Captures)
        {
            Console.WriteLine(c.Value);
        }
    
        Console.WriteLine();
    }
