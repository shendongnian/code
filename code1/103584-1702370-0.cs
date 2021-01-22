    string[] test = { "01:02:03", "1:02:03", "1:2:03", "1:02:3", "01:2:3", "1:2:3" };
    foreach (string s in test)
    {
        DateTime d = DateTime.ParseExact(s, "H:m:s", null);
        Console.WriteLine(d);
    }
