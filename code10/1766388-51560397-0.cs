    class Program
        {
            static void Main(string[] args)
            {
                bool repeat = true;
                while (repeat)
                {
                    DoTheGame();
                    Console.WriteLine("Go again? Y/N");
                    string go = Console.ReadLine();
                    if (go == "Y" || go == "y")
                    {
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
                    }
                }
            }
    
            public static void DoTheGame()
            {
                bool correct = false;
    
                int guess = 0;
                int totalGuess = 0;
    
                Random random = new Random();
                int returnNum = random.Next(1, 100);
    
                Console.WriteLine("*** Welcome to the Hi-Lo game ***");
                Console.WriteLine("The computer chose a number between 1 and 100, you guess it");
    
                do
                {
                    Console.WriteLine("Enter your guess: ");
                    guess = int.Parse(Console.ReadLine());
    
                    if (guess < returnNum)
                    {
                        Console.WriteLine("Your guess is too low!");
                        totalGuess++;
                    }
    
                    else if (guess > returnNum)
                    {
                        Console.WriteLine("Your guess is too high!");
                        totalGuess++;
                    }
    
                    else if (guess == returnNum)
                    {
                        correct = true;
                        totalGuess++;
                        Console.WriteLine("*** YOU GOT IT! ***");
                        Console.WriteLine("Total try: {0}", totalGuess);
                    }
                } while (!correct);
            }
        }
