    class Program
    {
        class ThreadData
        {
            public LockManager<int> LockManager { get; set; }
            public int[] Work { get; set; }
            public AutoResetEvent Done { get; set; }
        }
        static void Main(string[] args)
        {
            int[] forA = new int[] {5, 8, 9, 12};
            int[] forB = new int[] {7, 8, 9, 13, 14 };
            LockManager<int> lockManager = new LockManager<int>();
            ThreadData tdA = new ThreadData
            {
                LockManager = lockManager,
                Work = forA,
                Done = new AutoResetEvent(false),
            };
            ThreadData tdB = new ThreadData
            {
                LockManager = lockManager,
                Work = forB,
                Done = new AutoResetEvent(false),
            };
            ThreadPool.QueueUserWorkItem(new WaitCallback(Worker), tdA);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Worker), tdB);
            WaitHandle.WaitAll(new WaitHandle[] { tdA.Done, tdB.Done });
        }
        static void Worker(object args)
        {
            Debug.Assert(args is ThreadData);
            ThreadData data = (ThreadData) args;
            try
            {
                foreach (int key in data.Work)
                {
                    data.LockManager.Lock(key);
                    Console.WriteLine("~{0}: {1}",
                        Thread.CurrentThread.ManagedThreadId, key);
                    // simulate the load the set for Key
                    Thread.Sleep(1000);
                }
                foreach (int key in data.Work)
                {
                    // Now free they locked keys
                    data.LockManager.Release(key);
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
            finally
            {
                data.Done.Set();
            }
        }
    }
