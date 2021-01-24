    Console.Write("Enter a limit to the prime numbers you want displayed: ");
    userInput = Console.ReadLine();
    
    int newUserInput;
    
    if (!int.TryParse(userInput, out newUserInput))
    {
        Console.WriteLine("\nThe value entered must be a whole number. Please try again: ");
    }
