    List<MyClass> sequence = new List<MyClass>()
    {
        new MyClass{ First = 1, Second = 10 },
        new MyClass{ First = 1, Second = 10 },
        new MyClass{ First = 2, Second = 11 },
        new MyClass{ First = 2, Second = 12 }
    };
    var doesntMatch = sequence
        .GroupBy(i => i.First)
        .Select(g => new
            { 
                Key = g.Key, 
                Values = g.Select(i => i.Second).Distinct()
            })
        .Where(i => i.Values.Count() > 1);
    foreach (var i in doesntMatch)
    {
        Console.WriteLine(
            "First = {0} contains {1} distinct values: {2}", i.Key, i.Values.Count(),
            String.Join(", ", i.Values.Select(n => n.ToString()).ToArray()));
    }
    // output: "First = 2 contains 2 distinct values: 11, 12"
