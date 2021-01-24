    var animals = new List<IAnimal>();
    for (int i = 0; i < 1000000; i++)
    {
        animals.Add(new Bear());
        animals.Add(new Cat());
    }
    // remove overhead of the first query
    int catsCount = animals.Where(x => x == x).Count();
    var whereIsTicks = new List<long>();
    var whereTypeTicks = new List<long>();
    var ofTypeTicks = new List<long>();
    var sw = Stopwatch.StartNew();
    // a performance test with a single pass doesn't make a lot of sense
    for (int i = 0; i < 100; i++)
    {
        sw.Restart();
        // Where (is) + Select
        catsCount = animals.Where(_ => _ is Cat).Select(_ => (Cat)_).Count();
        whereIsTicks.Add(sw.ElapsedTicks);
        // Where (enum) + Select
        sw.Restart();
        catsCount = animals.Where(_ => _.Type == AnimalTypes.Cat).Select(_ => (Cat)_).Count();
        whereTypeTicks.Add(sw.ElapsedTicks);
        // OfType
        sw.Restart();
        catsCount = animals.OfType<Cat>().Count();
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
