    static void Main(string[] args)
    {
        var numbers = new List<int> {1, 2, 2, 3, 4, 6, 9, 3, 2};
        var results = new List<List<int>>();
        var currentSet = new List<int>();
        foreach (var number in numbers)
        {
            if (number % 2 == 0)
            {
                currentSet.Add(number);
            }
            else
            {
                if (currentSet.Count > 1)
                {
                    results.Add(currentSet.ToList());
                }
                currentSet.Clear();
            }
        }
        if (currentSet.Count > 1)
        {
            results.Add(currentSet.ToList());
        }
        Console.WriteLine("Results:");
        foreach (var setOfNumbers in results)
        {
            Console.WriteLine(string.Join(",", setOfNumbers));
        }
        Console.ReadLine();
    }
