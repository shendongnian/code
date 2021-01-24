    private static int GetIntFromUser(string prompt)
    {
        int input;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out input));
        return input;
    }
    private static ConsoleKeyInfo GetKeyFromUser(string prompt)
    {
        Console.Write(prompt);
        var key = Console.ReadKey();
        Console.WriteLine();
        return key;
    }
