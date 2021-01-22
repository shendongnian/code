    object lockObj = new object();
    Task.Factory.StartNew((_) =>
    {
        System.Diagnostics.Debug.WriteLine("Task1 started");
        var l1 = GetData(lockObj, new[] { 1, 2, 3, 4, 5, 6, 7, 8 }).ToList();
    }, TaskContinuationOptions.LongRunning);
    Task.Factory.StartNew((_) =>
    {
        System.Diagnostics.Debug.WriteLine("Task2 started");
        var l2 = GetData(lockObj, new[] { 10, 20, 30, 40, 50, 60, 70, 80 }).ToList();
    }, TaskContinuationOptions.LongRunning);
---
    public IEnumerable<T> GetData<T>(object lockObj, IEnumerable<T> list)
    {
        lock (lockObj)
        {
            foreach (T x in list)
            {
                System.Diagnostics.Debug.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " returned "  + x );
                Thread.Sleep(1000);
                yield return x;
            }
        }
    }
