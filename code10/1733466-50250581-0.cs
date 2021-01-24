    static void Main(string[] args)
    {
        var input = Console.ReadLine();
    
        long loopCounter = 0;
        long.TryParse(input, out loopCounter);
    
        for (int i = 0; i < loopCounter; i++)
        {
            Console.WriteLine("My Message");
        }
        
        Console.ReadKey();
    }
