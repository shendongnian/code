    string s = "dasglakgsklg";
    if (Regex.IsMatch(s, "^[a-z]+$", RegexOptions.IgnoreCase))
    {
        Console.WriteLine("Only letters in a-z.");
    }
    else
    {
        // Not only letters in a-z.
    }
