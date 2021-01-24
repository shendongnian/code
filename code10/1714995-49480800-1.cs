    private static int GetIntFromUser(string prompt)
    {
        int result;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
    private static decimal GetDecimalFromUser(string prompt)
    {
        decimal result;
        do
        {
            Console.Write(prompt);
        } while (!decimal.TryParse(Console.ReadLine(), out result));
        return result;
    }
    private static string GetInputFromUser(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
