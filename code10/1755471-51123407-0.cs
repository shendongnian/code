    var animals = new List<IAnimal>();
    for (int i = 0; i < 1000000; i++)
    {
        animals.Add(new Bear());
        animals.Add(new Cat());
    }
    // remove overhead of the first query
    var cats = animals.Where(x => x == x).ToArray();
    var whereIsTicks = new List<long>();
    var whereTypeTicks = new List<long>();
    var ofTypeTicks = new List<long>();
    var sw = Stopwatch.StartNew();
    // a performance test with a single pass doesn't make a lot of sense
    for (int i = 0; i < 100; i++)
    {
        sw.Restart();
        // Where (is) + Select
        cats = animals.Where(_ => _ is Cat).Select(_ => (Cat)_).ToArray();
        whereIsTicks.Add(sw.ElapsedTicks);
        // Where (enum) + Select
        sw.Restart();
        cats = animals.Where(_ => _.Type == AnimalTypes.Cat).Select(_ => (Cat)_).ToArray();
        whereTypeTicks.Add(sw.ElapsedTicks);
        // OfType
        sw.Restart();
        cats = animals.OfType<Cat>().ToArray();
        ofTypeTicks.Add(sw.ElapsedTicks);
    }
    sw.Stop();
    // get the average run time for each test in an easy-to-print format
    var results = new List<Tuple<string, double>>
    {
        Tuple.Create("Where (is) + Select", whereIsTicks.Average()),
        Tuple.Create("Where (type) + Select", whereTypeTicks.Average()),
        Tuple.Create("OfType", ofTypeTicks.Average()),
    };
    // print results orderer by time taken
    foreach (var result in results.OrderBy(x => x.Item2))
    {
        Console.WriteLine($"{result.Item1} => {result.Item2}");
    }
