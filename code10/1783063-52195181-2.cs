    private static int GetIntFromUser(string prompt, int minValue, int maxValue)
    {
        Console.Write(prompt);
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || 
            result < minValue || 
            result > maxValue)
        {
            Console.WriteLine("Error: number must be from " + minValue + " to " + maxValue);
            Console.Write(prompt);
        }
        return result;
    }
