    static class BenchmarkExtension {
        public static void Times(this int times, string description, Action action) {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < times; i++) {
                action();
            }
            watch.Stop();
            Console.WriteLine("{0} ... Total time: {1}ms ({2} iterations)", 
                description,  
                watch.ElapsedMilliseconds,
                times);
        }
    }
