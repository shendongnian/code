    string pattern = @"(?<=href=""|>)http://.+?(?=<|"")";
    foreach (string input in inputs)
    {
        Match m = Regex.Match(input, pattern);
        if (m.Success)
        {
            Console.WriteLine(m.Value);
        }
    }
