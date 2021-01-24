    Console.Write("Row (1-3): ");
    int UserRowChoice = 0;
    if(int.TryParse(Console.ReadLine(), out UserRowChoice))
    {  
        if (UserRowChoice < 1 || UserRowChoice > 3)
        {
            ThrowError("You either typed a number that was less than 1 or greater than 3.  You've lost your turn.");
            Console.ReadKey();
            RunGame(T1, CurrentPlayer, Winner);
        }
    }
    else
    {
        ThrowError("You typed a string instead of an integer.  You've lost your turn."); 
        Console.ReadKey(); 
        RunGame(T1, CurrentPlayer, Winner); 
    }
