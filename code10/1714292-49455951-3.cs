    private static void Main()
    {
        var length = Convert.ToInt32(Console.ReadLine());
        var halfway = length / 2;
        var items = new SortedDictionary<int, List<string>>();
        for (int inputLine = 0; inputLine < length; inputLine++)
        {
            var input = Console.ReadLine().Split();
            var sortIndex = Convert.ToInt32(input[0]);
            var value = inputLine < halfway ? "-" : input[1];
            if (items.ContainsKey(sortIndex)
            {
                items[sortIndex].Add(value);
            }
            else
            {
                items.Add(sortIndex, new List<string> {value});
            }
        }
        Console.WriteLine(string.Join(" ", items.SelectMany(i => i.Value)));
        // Not submitted to website, but for local testing:
        Console.Write("\n\nPress any key to exit...");
        Console.ReadKey();
    }
