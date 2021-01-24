    private static void Main()
    {
        var length = Convert.ToInt32(Console.ReadLine());
        var halfway = length / 2;
        var items = new List<string>();
        for (int i = 0; i < length; i++)
        {
            var input = Console.ReadLine();
            items.Add(i < halfway ? input.Split()[0] + " -" : input);
        }
        var output = items
            .OrderBy(i => int.Parse(i.Split()[0]))
            .Select(i => i.Split()[1]);
        Console.WriteLine(string.Join(" ", output));
        Console.Write("\n\nPress any key to exit...");
        Console.ReadKey();
    }
