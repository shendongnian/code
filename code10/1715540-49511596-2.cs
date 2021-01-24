    class WorkBench
    {
        private static readonly Stopwatch S = new Stopwatch();
        private static long[] RunOnce()
        {
            var results = new long[3];
            var myArray = Enumerable.Range(0, 1000000).ToList();
            int x = 1;
            S.Restart();
            for (int i = 0; i < myArray.Count; i++)
            {
                x = i + 1;
            }
            S.Stop();
            results[0] = S.ElapsedTicks;
            S.Restart();
            int c = myArray.Count;
            for (int i = 0; i < c; i++)
            {
                x = i - 1;
            }
            S.Stop();
            results[1] = S.ElapsedTicks;
            results[2] = x;
            return results;
        }
        private static void Main(string[] args)
        {
            var results = new List<Tuple<long, long>>();
            for (int i = 0; i < 1500; i++)
            {
                var workBenchResult = RunOnce();
                results.Add(Tuple.Create(workBenchResult[0], workBenchResult[1]));
            }
            var average = Tuple.Create(results.Average(r => r.Item1), results.Average(r => r.Item2));
            Console.WriteLine($"Average 1: {Math.Round(average.Item1, 4)}");
            Console.WriteLine($"Average 2: {Math.Round(average.Item2, 4)}");
        }
