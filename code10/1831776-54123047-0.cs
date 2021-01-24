    Console.WriteLine("What is your name?");
    string name = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Your name is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("name");
    Console.WriteLine(); //linebreak
    Console.ResetColor(); //reset to default values
