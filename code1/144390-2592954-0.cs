    string input = "Hello, -this- is a string";
    string[] searchString = { "Hello", "this" };
    string pattern = String.Join(@"\W+", searchString);
    
    foreach (Match m in Regex.Matches(input, pattern))
    {
        Console.WriteLine(m.Value);
    }
