    class Program
    {
        public static Int64 UnsafeSharedData;
        public static Int64 SafeSharedData;
        static void Main(string[] args)
        {
            Action<Int32> unsafeAdd = i => { UnsafeSharedData += i; };
            Action<Int32> unsafeSubtract = i => { UnsafeSharedData -= i; };
            Action<Int32> safeAdd = i => Interlocked.Add(ref SafeSharedData, i);
            Action<Int32> safeSubtract = i => Interlocked.Add(ref SafeSharedData, -i);
            WaitHandle[] waitHandles = new[] { new ManualResetEvent(false), 
                                               new ManualResetEvent(false),
                                               new ManualResetEvent(false),
                                               new ManualResetEvent(false)};
            Action<Action<Int32>, Object> compute = (a, e) =>
                                                {
                                                    for (Int32 i = 1; i <= 1000000; i++)
                                                    {
                                                        a(i);
                                                        Thread.Sleep(0);
                                                    }
                                                    ((ManualResetEvent) e).Set();
                                                };
            ThreadPool.QueueUserWorkItem(o => compute(unsafeAdd, o), waitHandles[0]);
            ThreadPool.QueueUserWorkItem(o => compute(unsafeSubtract, o), waitHandles[1]);
            ThreadPool.QueueUserWorkItem(o => compute(safeAdd, o), waitHandles[2]);
            ThreadPool.QueueUserWorkItem(o => compute(safeSubtract, o), waitHandles[3]);
            WaitHandle.WaitAll(waitHandles);
            Debug.WriteLine("Unsafe: " + UnsafeSharedData);
            Debug.WriteLine("Safe: " + SafeSharedData);
        }
    }
