        // sample data
        var original = new Dictionary<int, int?>();
        for (int i = 1; i <= 10; i++)
        {
            original.Add(i, null);
        }
        var updated = new Dictionary<int, int>();
        updated.Add(2, 67);
        updated.Add(4, 90);
        updated.Add(5, 98);
        updated.Add(11, 20); // add
        // merge
        foreach (var pair in updated)
        {
            original[pair.Key] = pair.Value;
        }
        // show results
        foreach (var pair in original.OrderBy(x => x.Key))
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
