    char winTake = Console.ReadKey().KeyChar; // gets the input character
    char[] validChars = new char[] { 'A', 'a', 'L', 'l' };         
    while (!validChars.Any(x => x == winTake))
    {
        Console.WriteLine("Please only type in A or L and do not leave blank, Retry:"); 
        winTake = Console.ReadKey().KeyChar;
    }
    Console.WriteLine("Completed");
