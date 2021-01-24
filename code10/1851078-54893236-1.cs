    private static void Welcome()
    {
        Console.WriteLine("Hello Traveller, What is your name?");
        playerName = Console.ReadLine();
        Console.WriteLine("Well Hello, " + playerName);
        Console.WriteLine("You are alone in a dark dungeon. You can see a room behind you and a long hall in front of you.");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("You hear an enemy nearby...");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("(fight) or (hide)?");
        Console.ForegroundColor = ConsoleColor.Gray;
        playerChoice = Console.ReadLine();
    }
