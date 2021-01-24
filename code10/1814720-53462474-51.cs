    private static int GetIntegerFromUser(string prompt)
    {
        int value;
        Console.Write($"{prompt}: ");
        
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("That is not a valid value. Please try again.");
            Console.Write($"{prompt}: ");
        }
        return value;
    }
