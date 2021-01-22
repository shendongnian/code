    // define your input string:
    string input = "test1, 1, anotherstring, 5, yetanother, 400";
    // split it, remove excessive whitespace from all parts, and group them together:
    IEnumerable<string[]> pairedInput = input
                                        .Split(',')
                                        .Select(part => part.Trim())
                                        .InGroupsOf(2);  // <-- used here!
    // see if it worked:
    foreach (string[] pair in pairedInput)
    {
        Console.WriteLine(string.Join(", ", pair));
    }
