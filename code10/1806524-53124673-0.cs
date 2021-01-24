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
        Console.Write("Enter a search term: ");
        string searchTerm = Console.ReadLine();
        var matches = bookTitles.Where(title => 
            title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) > -1);
        if (matches.Any())
        {
            Console.WriteLine("\nResults:");
            Console.WriteLine(" - " + string.Join("\n - ", matches));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNo matches found.");
            Console.ResetColor();
        }
        Console.Write("\nDone! Press any key to exit...");
        Console.ReadKey();
    }
