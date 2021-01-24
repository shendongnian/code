    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    namespace ManyTasks
    {
    class Program
    {
        public static void Main()
        {
            int n = 1000000;
            Task<int>[] tasks = new Task<int>[n];
            var sw = new Stopwatch();
            sw.Start();
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    int j = i;
                    tasks[i] = new Task<int>(() =>
                    {
                        if (j == 0)
                            return 1;
                        var result = tasks[j - 1].Result + 1;
                        return result;
                    });
                    tasks[i].Start();
                    tasks[i].Wait();
                }
            }).Wait();
            sw.Stop();
            Console.WriteLine(tasks[n - 1].Result);
            Console.WriteLine($"time: {sw.Elapsed.TotalMilliseconds:0.000}ms");
        }
    }
    }
