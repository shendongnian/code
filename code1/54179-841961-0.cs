    string test = "RR1234566-001";
    string rx = @"^([A-Za-z]{2})(\d{7})(\-)(\d+)$";
    Match m = Regex.Match(test, rx, RegexOptions.IgnoreCase);
    if (m.Success)
    {
        Console.WriteLine(m.Groups[1].Value);    // RR
        Console.WriteLine(m.Groups[2].Value);    // 1234566
        Console.WriteLine(m.Groups[3].Value);    // -
        Console.WriteLine(m.Groups[4].Value);    // 001
    }
