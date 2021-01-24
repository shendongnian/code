    using System;
    namespace HiLoGame
    {
        class Program
        {
            static void Main(string[] args)
            {
                string go = string.Empty;
    
                Console.WriteLine("*** Welcome to the Hi-Lo game ***");
                Console.WriteLine("The computer chose a number between 1 and 100, you guess it");
                do
                {
                    GameLoop();
    
                    Console.WriteLine("Go again? Y/N");
                    go = Console.ReadLine();
                } while (go == "Y" || go == "y");
    
            }
    
            private static void GameLoop()
            {
                bool correct = false;
                bool repeat = true;
                int guess = 0;
                int totalGuess = 0;
    
                Random random = new Random();
                int returnNum = random.Next(1, 100);
    
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
    }
