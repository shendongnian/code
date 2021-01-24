    public class Program {
        public static void Main(string[] args) {
            DownloadAsync().Wait();
            Console.ReadKey();
        }
        private static async Task DownloadAsync() {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var tasks = new List<Task>();
            for (int index = 0; index < 60; index++) {
                var tmp = index;
                var task = Task.Run(() => {
                    ThreadPool.GetAvailableThreads(out int wt, out _);
                    ThreadPool.GetMaxThreads(out int mt, out _);
                    Console.WriteLine($"Started: {tmp} on thread {Thread.CurrentThread.ManagedThreadId}. Threads in pool: {mt - wt}");
                    var res = DoStuff(tmp).Result;
                    Console.WriteLine($"Done {res} on thread {Thread.CurrentThread.ManagedThreadId}");
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks.ToArray());
            sw.Stop();
            Console.WriteLine($"Process took: {sw.Elapsed.Seconds} sec {sw.Elapsed.Milliseconds} ms");
        }
        public static async Task<string> DoStuff(int i) {
            await Task.Delay(1000); // web request
            Console.WriteLine($"continuation of {i} on thread {Thread.CurrentThread.ManagedThreadId}"); // continuation
            return i.ToString();
        }
    }
