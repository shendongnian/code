    var strings = new List<string> { "Just a test.", "Another test." };
    
    Console.Write("Search here: ");
    string userInput = Console.ReadLine();
    
    var matching = strings.Where(s => s.Contains(userInput)).ToList();
    if (matching.Count == 0) {
        Console.WriteLine("No match.");
    } else {
        foreach (var match in matching) {
            Console.WriteLine(match);
        }
    }
