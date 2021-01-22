    List<string> inputs = new List<string>()
    {
        "1.234.567,89",
        "1 234 567,89",
        "1 234 567.89",
        "1,234,567.89",
        "123456789",
        "1234567,89",
        "1234567.89",
    };
    string output;
    foreach (string input in inputs)
    {
        // Unify string (no spaces, only .)
        output = input.Trim().Replace(" ", "").Replace(",", ".");
        // Split it on points
        string[] split = output.Split('.');
        if (split.Count() > 1)
        {
            // Take all parts except last
            output = string.Join("", split.Take(split.Count()-1).ToArray());
            // Combine token parts with last part
            output = string.Format("{0}.{1}", output, split.Last());
        }
        // Parse double invariant
        double d = double.Parse(output, CultureInfo.InvariantCulture);
        Console.WriteLine(d);
    }
