    static void CheckRandomValueAgainstCriteria(Predicate<int> predicate, int maxValue)
    {
        Random random = new Random();
        int value = random.Next(0, maxValue);
    
        Console.WriteLine(value);
    
        if (predicate(value))
        {
            Console.WriteLine("The random value met your criteria.");
        }
        else
        {
            Console.WriteLine("The random value did not meet your criteria.");
        }
    }
...
    CheckRandomValueAgainstCriteria(i => i < 20, 40);
