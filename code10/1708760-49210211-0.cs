It looks like it's working to me after modifying the PerformTaskAndCancelPreviousTasks method to take CancellationTokenSource instead of CancellationToken. Stacked up calls do get cancelled.
        public class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////
            // Test
            //
            // Out:
            //  Thread [852] performed the work
            //  Was last executing thread: FALSE. Was #897
            //  QueueUserWorkItem Call 1762
            //  Thread [854] performed the work
            //  Was last executing thread: FALSE. Was #1412
            //  QueueUserWorkItem Call 1391
            //  Thread [1836] performed the work
            //  Was last executing thread: TRUE. Was #2000
            //  QueueUserWorkItem Call 1984
            //
            ///////////////////////////////////////////////////////////////////////////////
            Manager mgr = new Manager();
            
            // 2000 rapid updates 
            for (int i = 0; i < 2000; i++)
            {
                new Thread(new ParameterizedThreadStart((id) => {
                    // Thread.Sleep(2000 - (int) id);
                    Random rand = new Random();
                    Thread.Sleep(rand.Next(2, 500));
                    CancellationTokenSource ctSource = new CancellationTokenSource();
                    ThreadPool.QueueUserWorkItem(async (state) => await mgr.PerformTaskAndCancelPreviousTasks(ctSource, (int) id, rand.Next(7, 2500)));
                })).Start(i);
            };
            Task.Delay(15000).Wait(); // Keep ThreadPool alive
        }
    }
    public class Manager
    {
        private static readonly ConcurrentBag<CancellationTokenSource> CancelTokens = new ConcurrentBag<CancellationTokenSource>();
        private static volatile int AtomicCounter = 0;
        
        // Below method gets called like this
        // HostingEnvironment.QueueBackgroundWorkItem(async (cancelationToken) => await PerformTaskAndCancelPreviousTasks(cancelationToken));
        public async Task PerformTaskAndCancelPreviousTasks(CancellationTokenSource cts, int tN, int delay)
        {
            try
            {
                Interlocked.Increment(ref AtomicCounter);
                // Cancel all previous tasks
                while (!CancelTokens.IsEmpty)
                {
                    CancellationTokenSource previousTaskCancelTokenSource = null;
                    CancelTokens.TryTake(out previousTaskCancelTokenSource);
                    if (previousTaskCancelTokenSource != null)
                    {
                        previousTaskCancelTokenSource.Cancel();
                    }
                }
                CancelTokens.Add(cts); // Add this task's CancellationToken to ConcurrentBag
                await Task.Delay(delay); // Simulate network request
                // Only the newest task needs to run this, for performance
                if (!cts.Token.IsCancellationRequested)
                {
                    // Rehydrate a cache item that is a collection
                    Console.WriteLine(string.Format("Thread [{0}] performed the work", Thread.CurrentThread.ManagedThreadId));
                    Console.WriteLine(string.Format("Was last executing thread: {0}. Was #{1}", AtomicCounter == 2000 ? "TRUE" : "FALSE", AtomicCounter));
                    Console.WriteLine(string.Format("QueueUserWorkItem Call {0}", tN));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred in:\r\n" + e.StackTrace);
            }
        }
    }
