    class Program {
        static Random rg = new Random();
        static object lockObject = new object();
        static void Main(string[] args) {
            int count = 64;
            Pair[] pairs = new Pair[count];
            for(int i = 0; i < count; i++) {
                pairs[i] = new Pair(i, 2 * i);
            }
            TrackedWorkers workers = new TrackedWorkers(count);
            workers.LaunchWorkers(SleepAndAdd, pairs.Cast<object>().ToArray());
            Console.WriteLine(
                "Number successful: {0}",
                workers.SuccessfulWorkers.Count()
            );
            Console.WriteLine(
                "Number failed: {0}",
                workers.FailedWorkers.Count()
            );
        }
        static bool SleepAndAdd(object o) {
            Pair pair = (Pair)o;
            int timeout;
            double d;
            lock (lockObject) {
                timeout = rg.Next(1000);
                d = rg.NextDouble();
            }
            Thread.Sleep(timeout);
            bool success = d < 0.5;
            if (success) {
                Console.WriteLine(pair.First + pair.Second);
            }
            return (success);
            
        }
    }
