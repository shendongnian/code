    // define your input string:
    string input = "test1, 1, anotherstring, 5, yetanother, 400";
    // split it:
    IEnumerable<string[]> pairedInput = input
                                        .Split(',')
                                        .ToGroupsOf(2);
    // see if it worked:
    foreach (string[] pair in pairedInput)
    {
        Console.WriteLine("{0}, {1}", pair[0], pair[1]);
    }
