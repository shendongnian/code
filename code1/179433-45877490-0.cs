    Console.Write("Password ");
    ConsoleColor origBG = Console.BackgroundColor; // Store original values
    ConsoleColor origFG = Console.ForegroundColor;
    Console.BackgroundColor = ConsoleColor.Red; // Set the block colour (could be anything)
    Console.ForegroundColor = ConsoleColor.Red;
    string Password = Console.ReadLine(); // read the password
    Console.BackgroundColor= origBG; // revert back to original
    Console.ForegroundColor= origFG;
