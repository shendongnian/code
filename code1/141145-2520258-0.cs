    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            using (var countdown = new Countdown(items.Length))
            {
                foreach (var item in items)
                {
                    ThreadPool.QueueUserWorkItem(o =>
                    {
                        Thread.SpinWait(100000000);
                        Console.WriteLine("Thread Done!");
                        countdown.Signal();
                    });
                }
                countdown.Wait();
            }
            Console.WriteLine("Job Done!");
            Console.ReadKey();
        }
        public class Countdown : IDisposable
        {
            private readonly ManualResetEvent done;
            private readonly int total;
            private volatile int current;
            public Countdown(int total)
            {
                this.total = total;
                current = total;
                done = new ManualResetEvent(false);
            }
            public void Signal()
            {
                lock (done)
                {
                    if (current > 0 && --current == 0)
                        done.Set();
                }
            }
            public void Wait()
            {
                done.WaitOne();
            }
            public void Dispose()
            {
                done.Dispose();
            }
        }
    } 
