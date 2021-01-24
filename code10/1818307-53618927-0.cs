    static void Main(string[] args)
    {
        var filePath = @"c:\temp\temp.txt";
        var words = File.ReadAllLines(filePath);
            
        Console.Write("Enter a search term: ");
        var searchTerm = Console.ReadLine();
            
        if (words.Contains(searchTerm, StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("We have your word!");
        }
        else
        {
            Console.WriteLine("We do not have your word");
        }
        Console.ReadKey();
    }
