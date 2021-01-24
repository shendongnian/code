    string input = Console.ReadLine(); 
    string[] tokens = input.Split(' ');
    
    string hi = tokens[0];
    string optional = tokens.Length > 1 ? tokens[1] : null; // make sure we have enough elements
    
    Console.WriteLine(hi);
    
    // null check before using the optional value
    if (optional != null)
        Console.WriteLine(optional);
    // or 
    Console.WriteLine(optional ?? "Optional value is null..");
