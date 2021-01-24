    static void Main(string[] args)
    {
        var bookTitles = new List<string>
        {
            "The Catcher in the Rye",
            "Pride and Prejudice",
            "The Great Gatsby",
            "Alice's Adventures in Wonderland",
            "Moby Dick",
            "Gulliver's Travels",
            "Hamlet",
            "The Canterbury Tales",
            "Catch-22",
            "The Adventures of Huckleberry Finn"
        };
        bool tryAgain = true;
        while (tryAgain)
        {
            Console.Write("Enter a search term: ");
            string searchTerm = Console.ReadLine();
            var results = bookTitles.Where(title =>
                title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) > -1);
            if (results.Any())
            {
                Console.WriteLine("\nResults:");
                Console.WriteLine(" - " + string.Join("\n - ", results));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo matches found.");
                Console.ResetColor();
            }
            Console.Write("\nTry again? (y/n): ");
            if (Console.ReadKey().Key == ConsoleKey.N) tryAgain = false;
            Console.WriteLine("\n");
        }
        Console.Write("\nDone! Press any key to exit...");
        Console.ReadKey();
    }
