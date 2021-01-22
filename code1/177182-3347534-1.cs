    private static void ExecuteFor()
    {
        while (true)
        {
            Console.WriteLine("for");
            if (string.IsNullOrEmpty(Console.ReadLine()))
            {
                Console.WriteLine("Exit for.");
                return;
            }
        }
    }
