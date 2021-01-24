    private static Random _random = new Random();
    static void Main(string[] args)
    {
        // Pick a random number between 1 and 100 for the user to guess
        int secretNumber = _random.Next(1, 101);
        int USER_LIMIT = 3;
        int userGuess = 0;
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        while (userGuess < USER_LIMIT)
        {
            userGuess++;
            Console.Write("Guess a number between 1 and 100: ");
            int num;
            if (int.TryParse(Console.ReadLine(), out num))
            {
                if (num > secretNumber)
                {
                    Console.WriteLine("Your guess is too high!\n");
                }
                else if (num < secretNumber)
                {
                    Console.WriteLine("Your guess is too low!\n");
                }
                else
                {
                    Console.WriteLine($"\nGood job, {name}! That only took {userGuess} guesses!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }
        }
        Console.WriteLine("\nGame Over!");
        if (userGuess == USER_LIMIT) Console.WriteLine($"\nThe number was: {secretNumber}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
