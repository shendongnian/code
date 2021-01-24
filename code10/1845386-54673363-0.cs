    class Program
    {
        static void Main(string[] args)
        {
            var work = new List<(string, string, string)> { ("a", "a", "a"), ("a", "a", "b"), ("a", "a", "c"), ("a", "a", "d"), ("a", "a", "e"), ("a", "a", "f"), ("a", "a", "g") };
            var threads = 3;
            var opts = new ParallelOptions { MaxDegreeOfParallelism = threads };
            var results = Parallel.ForEach(work, opts, Test);
            //do a proper timeout?
            while (!results.IsCompleted)
            {
                Thread.Sleep(10);
                Console.WriteLine("Waiting to finish...");
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
        static void Test((string, string, string) item)
        {
            //Do work....
            Thread.Sleep(100);
            Console.WriteLine($"{item.Item1}:{item.Item2}:{item.Item3}");
        }
    }
