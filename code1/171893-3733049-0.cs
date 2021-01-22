    string[] s1 = new string[] { };
    string[] s2 = new string[] { "abc" };
    // Outputs "DEFAULT" because the sequence s1 is empty.
    foreach (var s in s1.DefaultIfEmpty("DEFAULT"))
        Console.WriteLine(s);
    // Outputs "abc" from the sequence s2 and nothing else.
    foreach (var s in s2.DefaultIfEmpty("DEFAULT"))
        Console.WriteLine(s);
