    [TestMethod]
    public void PerformanceTest()
    {
        var random = new Random();
        var clients = Enumerable.Range(0, 10000)
                .Select(i => new Person { FirstName = $"{random.Next()}",      
                                          LastName = $"{random.Next()}" })
                .ToList();
        var employees = Enumerable.Range(0, 10000)
                .Select(i => new Person { FirstName = $"{random.Next()}", 
                                          LastName = $"{random.Next()}" })
                .ToList();
        var joinElapsedMs = MeasureAverageElapsedMs(() =>
            {
                var isDuplicated = clients.Join(employees,
                        c => new { c.FirstName, c.LastName },
                        e => new { e.FirstName, e.LastName },
                        (c, e) => new { c, e })
                        .Any();
            });
        var intersectElapsedMs = MeasureAverageElapsedMs(() =>
            {
                var clientNames = clients.Select(c => new { c.FirstName, c.LastName });
                var employeeNames = employees.Select(e => new { e.FirstName, e.LastName });
                var isDuplicated = clientNames.Intersect(employeeNames).Any();
            });
        var anyAnyElapsedMs = MeasureAverageElapsedMs(() =>
            {
                var isDuplicated = clients.Any(c => employees.Any(
                        e => c.FirstName == e.FirstName && c.LastName == e.LastName));
            });
        Console.WriteLine($"{nameof(joinElapsedMs)}: {joinElapsedMs}");
        Console.WriteLine($"{nameof(intersectElapsedMs)}: {intersectElapsedMs}");
        Console.WriteLine($"{nameof(anyAnyElapsedMs)}: {anyAnyElapsedMs}");
    }
    private static double MeasureAverageElapsedMs(Action action) =>
        Enumerable.Range(0, 10).Select(_ => MeasureElapsedMs(action)).Average();
    private static long MeasureElapsedMs(Action action)
    {
        var stopWatch = Stopwatch.StartNew();
        action();
        return stopWatch.ElapsedMilliseconds;
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
