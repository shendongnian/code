    class Program
    {
        static string PATH = "F:\\users\\llopez\\media\\photos";
        static Func<string, bool> WHERE = s => s.EndsWith(".CR2") || s.EndsWith(".html");
        static void Main(string[] args)
        {
            using (new Profiler())
            {
                var accepted = Directory.GetFiles(PATH, "*.*", SearchOption.AllDirectories)
                    .Where(WHERE);
                foreach (string f in accepted) { }
            }
            using (new Profiler())
            {
                var files = traverse(PATH, WHERE);
                foreach (string f in files) { }
            }
            Console.ReadLine();
        }
        static IEnumerable<string> traverse(string path, Func<string, bool> filter)
        {
            foreach (string f in Directory.GetFiles(path).Where(filter))
            {
                yield return f;
            }
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in traverse(d, filter))
                {
                    yield return f;
                }
            }
        }
    }
    class Profiler : IDisposable
    {
        private Stopwatch stopwatch;
        public Profiler()
        {
            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
        }
        public void Dispose()
        {
            stopwatch.Stop();
            Console.WriteLine("Runing time: {0}ms", this.stopwatch.ElapsedMilliseconds);
            Console.WriteLine("GC.GetTotalMemory(false): {0}", GC.GetTotalMemory(false));
        }
    }
