        static IEnumerable<int> GenerateNumbers(int amount)
        {
            Random r = new Random();
            for (int i = 0; i < amount; i++)
                yield return r.Next(100);
        }
        static void Main(string[] args)
        {
            var numbers = GenerateNumbers(6_000_000).ToList();
            Stopwatch sw = Stopwatch.StartNew();
            int mode = numbers.GroupBy(number => number).OrderByDescending(group => group.Count()).Select(k =>
            {
                int count = k.Count();
                return new { Mode = k.Key, Count = count };
            }).FirstOrDefault().Mode;
            sw.Stop();
            Console.WriteLine($"Lambda: found {mode} in {sw.ElapsedMilliseconds} ms.");
            sw = Stopwatch.StartNew();
            mode = findMostCommon(numbers)[0].Value;
            sw.Stop();
            Console.WriteLine($"Manual: found {mode} in {sw.ElapsedMilliseconds} ms.");
            // create a dictionary
            var dictionary = new ConcurrentDictionary<int, int>();
            sw = Stopwatch.StartNew();
            // parallel the iteration ( we can because concurrent dictionary is thread safe-ish
            numbers.AsParallel().ForAll((number) =>
            {
                // add the key if it's not there with value of 1 and if it's there it use the lambda function to increment by 1
                dictionary.AddOrUpdate(number, 1, (key, old) => old + 1);
            });
            mode = dictionary.Aggregate((x, y) => { return x.Value > y.Value ? x : y; }).Key;
            sw.Stop();
            Console.WriteLine($"Dictionary: found {mode} in {sw.ElapsedMilliseconds} ms.");
            Console.ReadLine();
        }
