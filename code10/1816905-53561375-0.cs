    class Item { public string Id { get; set; } }
    class Program
    {
        private static Random rng = new Random();
        private static string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 2_700_000)
                .Select(x => string.Join("", Enumerable.Range(5, rng.Next(20)).Select(y => characters[rng.Next(0, characters.Length)])))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Select(x => new {Order = rng.Next(), Item = new Item {Id = x }})
                .OrderBy(x => x.Order)
                .Select(x => x.Item)
                .ToList();
            Console.WriteLine("Master List Size: {0}", list.Count);
            var matches = list.Take(350_000).Select(x => x.Id).ToList();
            Console.WriteLine("Matches List Size: {0}", matches.Count);
            var dict = list.ToDictionary(x => x.Id, x => x, StringComparer.CurrentCultureIgnoreCase);
            var results = new List<Item>();
            var sw = new Stopwatch();
            Console.WriteLine("CurrentCultureIgnoreCase Elapsed Time (avg): {0}",
                Enumerable.Range(1, 10).Select(x =>
                {
                    sw.Start();
                    foreach (var m in matches)
                        if (dict.TryGetValue(m, out var item))
                            results.Add(item);
                    sw.Stop();
                    var t = sw.ElapsedMilliseconds;
                    sw.Reset();
                    return t;
                }).Average());
            dict = list.ToDictionary(x => x.Id.ToUpper(), x => x);
            Console.WriteLine("ToUpper() Elapsed Time (avg): {0}",
                Enumerable.Range(1, 10).Select(x =>
                {
                    sw.Start();
                    foreach (var m in matches)
                        if (dict.TryGetValue(m.ToUpper(), out var item))
                            results.Add(item);
                    sw.Stop();
                    var t = sw.ElapsedMilliseconds;
                    sw.Reset();
                    return t;
                }).Average());
            dict = list.ToDictionary(x => x.Id, x => x, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("OrdinalIgnoreCase Elapsed Time (avg): {0}",
                Enumerable.Range(1, 10).Select(x =>
                {
                    sw.Start();
                    foreach (var m in matches)
                        if (dict.TryGetValue(m, out var item))
                            results.Add(item);
                    sw.Stop();
                    var t = sw.ElapsedMilliseconds;
                    sw.Reset();
                    return t;
                }).Average());
        }
    }
    var cDict = new ConcurrentDictionary<string,Item>(dict);
    var cResults = new ConcurrentBag<Item>();
    Console.WriteLine("Parallel Elapsed Time (avg): {0}",
        Enumerable.Range(1, 10).Select(x =>
        {
            sw.Start();
            Parallel.ForEach(matches, new ParallelOptions{MaxDegreeOfParallelism = 20}, m =>
            {
                if (cDict.TryGetValue(m, out var item))
                    cResults.Add(item);
            });
            sw.Stop();
            var t = sw.ElapsedMilliseconds;
            sw.Reset();
            return t;
        }).Average());
