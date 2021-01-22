    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    namespace ParallelTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var results = new ConcurrentBag<int>();
                Parallel.For(0, 10, i =>
                {
                    results.Add(i * i);
                });
                foreach (int i in results)
                    System.Console.WriteLine(i);
            }
        }
    }
