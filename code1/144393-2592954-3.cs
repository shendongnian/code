    string input = "Hello, -this- is a string";
    string[] searchStrings = { "Hello", "this" };
    string pattern = String.Join(@"\W+", searchStrings);
    
    foreach (Match match in Regex.Matches(input, pattern))
    {
        Console.WriteLine(match.Value);
    }
