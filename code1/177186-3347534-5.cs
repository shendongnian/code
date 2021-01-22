    private static void ExecuteWhile()
    {
        do
        {
            Console.WriteLine("while");
        }
        while (!string.IsNullOrEmpty(Console.ReadLine()));
        Console.WriteLine("Exit while.");
    }
