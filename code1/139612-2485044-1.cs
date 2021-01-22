    string input = "123xx456yy789";
    // to reach the else branch set delimiters to new List();
    var delimiters = new List<string> { ".", "xx", "yy", "()" }; 
    if (delimiters.Count > 0)
    {
        string pattern = "("
                         + String.Join("|", delimiters.Select(d => Regex.Escape(d))
                                                      .ToArray())
                         + ")";
        string[] result = Regex.Split(input, pattern);
        foreach (string s in result)
        {
            Console.WriteLine(s);
        }
    }
    else
    {
        // nothing to split
        Console.WriteLine(input);
    }
