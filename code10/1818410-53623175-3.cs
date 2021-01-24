    private static List<int> GetListOfNumbers()
    {
        Console.Write("Enter a comma-separated list of numbers: ");
        return Console.ReadLine()
            .Split(',')
            .Where(item => item.Trim().All(char.IsNumber))
            .Select(int.Parse)
            .ToList();
    }
