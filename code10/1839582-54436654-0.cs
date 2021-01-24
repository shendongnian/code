    var list = new[]
    {
        new DummyClass{ Name = "A1", Value=1, Status= "A" },
        new DummyClass{ Name = "A1", Value=2, Status= "I" },
        new DummyClass{ Name = "A2", Value=3, Status= "I" },
        new DummyClass{ Name = "A2", Value=4, Status= "I" },
        new DummyClass{ Name = "A2", Value=5, Status= "A" },
        new DummyClass{ Name = "A3", Value=6, Status= "I" },
        new DummyClass{ Name = "A3", Value=7, Status= "I" },
    };
    var aggregate = list
        .OrderBy(item => item.Status)
        .GroupBy(item => item.Name)
        .Select(group => group.First());
    foreach (var item in aggregate)
    {
        Console.WriteLine($"{item.Name} - {item.Value} - {item.Status}");
    }
