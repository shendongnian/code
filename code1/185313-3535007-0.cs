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
        // unify string (no spaces, only . )
        output = input.Trim().Replace(" ", "").Replace(",", ".");
        // split it on points
        string[] split = output.Split('.');
        if (split.Count() > 1)
        {
            // take all parts except last
            output = string.Join("", split.Take(split.Count()-1).ToArray());
            // combine token parts with last part
            output = string.Format("{0}.{1}", output, split.Last());
        }
        // parse double invariant
        double d = double.Parse(output, CultureInfo.InvariantCulture);
        Console.WriteLine(d);
    }
