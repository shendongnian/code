    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Maths game!");
            Console.WriteLine("(Apologies for the glitchiness!)");
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine();
        
            // This object keeps track of scores
            ScoreKeeper scoreKeeper = new ScoreKeeper();
        
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("1 - Test your Maths against the clock!");
                Console.WriteLine("2 - Exit the application.");
                Console.WriteLine("3 - Top scores");
                Console.WriteLine();
                input = Console.ReadLine();
                intInput = int.Parse(input);
                if (intInput == 1)
                {
                    // You should avoid gotos.  Try writing a method instead
                    
                    // Play the game and get the player's score.
                    int newScore = PlayGame();
                    
                    // Have the score keeper record the new score.
                    scoreKeeper.RecordScore(newScore);
                }
                else if (intInput == 2)
                {
                    keepRunning = false;
                }
                else if (intInput == 3)
                {
                    // Get the top scores from the score keeper
                    int[] topScores = scoreKeeper.GetTop10Scores();
                    
                    // Print each score
                    for (int i = 0; i < topScores.Length; i++)
                    {
                        Console.WriteLine("{0}: {1}", i, topScores[i]);
                    }
                }            
            }
        }
        
        private int PlayGame()
        {
            // Put your game logic in here.  Return the score.
        }
    }
