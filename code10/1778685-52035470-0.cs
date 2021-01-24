    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                // Create some random bytes (using a seed to ensure it's the same bytes each time).
                var rng = new Random(12345);
                byte[] byteArr = new byte[500_000_000];
                rng.NextBytes(byteArr);
                // Time single-threaded.
                var sw = Stopwatch.StartNew();
                long sum = byteArr.Sum(x => (long)x);
                Console.WriteLine($"Single-threaded took {sw.Elapsed} to calculate sum as {sum}");
                // Time Plinq
                sw.Restart();
                sum = byteArr.AsParallel().Sum(x => (long)x);
                Console.WriteLine($"Plinq took {sw.Elapsed} to calculate sum as {sum}");
                // Time Parallel.ForEach() with partitioner.
                sw.Restart();
                sum = 0;
                Parallel.ForEach
                (
                    Partitioner.Create(0, byteArr.Length),
                    () => 0L,
                    (subRange, loopState, threadLocalState) =>
                    {
                        for (int i = subRange.Item1; i < subRange.Item2; i++)
                        {
                            threadLocalState += byteArr[i];
                        }
                        return threadLocalState;
                    },
                    finalThreadLocalState =>
                    {
                        Interlocked.Add(ref sum, finalThreadLocalState);
                    }
                );
                Console.WriteLine($"Parallel.ForEach with partioner took {sw.Elapsed} to calculate sum as {sum}");
            }
        }
    }
