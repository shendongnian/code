    private static int GetIntFromUser(string prompt)
    {
        int input;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out input));
        return input;
    }
