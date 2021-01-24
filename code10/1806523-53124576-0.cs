    var possibleStrings = new string[] { "This is a test", "Another test" };
    Console.WriteLine("Enter input: ");
    var userInput = Console.ReadLine();
    foreach (var match in possibleStrings.Where(ps => ps.Contains(userInput))
    {
        Console.WriteLine(match);
    }
