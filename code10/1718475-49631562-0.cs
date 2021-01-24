    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Highest number:");
                int maxNumber = Convert.ToInt32(Console.ReadLine());
                Random rand = new Random();
                int correctNumber = rand.Next(0, maxNumber);
    
                Console.WriteLine("Trying to guess number now..");
                int guessedNumber = 0;
    
                int lowBound = 0;
                int highBound = maxNumber;
                int guesses = 0;
                while(guessedNumber != correctNumber)
                {
                    guessedNumber = rand.Next(lowBound, highBound);
                    if(guessedNumber > correctNumber)
                    {
                        highBound /= 2;
                        lowBound /= 2;
                    }
                    else if(guessedNumber < correctNumber)
                    {
                        lowBound *= 2;
                        highBound *= 2;
                    }
                    ++guesses;
                }
                Console.WriteLine($"Took me {guesses} guesses.");
                Console.ReadKey();
            }
        }
