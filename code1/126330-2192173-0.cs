    string input = "blah blah blah (foo:this, bar:that)";
    string pattern = @"\((?:(?<Values>.*?):[^,\s]+[,\s]*)+\)";
    foreach (Match m in Regex.Matches(input, pattern))
    {
        foreach (Capture c in m.Groups["Values"].Captures)
        {
            Console.WriteLine(c.Value);
        }
    }
