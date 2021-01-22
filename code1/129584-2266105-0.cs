    Regex pattern = new Regex("^[a-zA-Z0-9]*$", RegexOptions.Compiled);
    for (int i = 0; i < 1000; i++)
    {
        string input = Console.ReadLine();
        pattern.IsMatch(input);
    }
