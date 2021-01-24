    public class Program
    {
        private static readonly Random Rnd = new Random();
        private static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        private static int GetInt(string prompt)
        {
            int result;
            while (!int.TryParse(GetString(prompt), out result)) ;// Console.WriteLine();
            return result;
        }
        private static ConsoleKeyInfo GetKey(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadKey();
        }
        private static bool PlayGame()
        {
            Console.Clear();
            Console.WriteLine("Guessing Game");
            Console.WriteLine("-------------");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");
            Console.WriteLine("Let's see how many guesses it takes you to find it!\n");
            int input, guesses = 0, myNumber = Rnd.Next(1, 101);
            var message = "Enter your guess (or '0' to quit): ";
            for (input = GetInt(message);            // Initialize input to user's value
                input != 0 && input != myNumber;     // Iterate until they guess correct or enter 0
                input = GetInt(message), guesses++)  // Get a new value on each iteration
            {
                Console.WriteLine(input < myNumber ? "Too low!" : "Too high!");
            }
            Console.WriteLine(input == myNumber
                ? $"Correct! That took {guesses} guesses."
                : $"Sorry you didn't get it! The number was: {myNumber}.");
            // Here we call Equals directly on the result of GetString
            return GetString("\nDo you want to play again (y/n)? ")
                .Equals("y", StringComparison.OrdinalIgnoreCase);
        }
        private static void Main()
        {
            while (PlayGame()) ; // Empty while loop body - keeps looping until they say "no"
            GetKey("Done! Press any key to exit...");
        }
    }
