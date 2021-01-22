        var list = new List<int>();
        ManualResetEvent[] handles = new ManualResetEvent[10];
        for (int i = 0; i < 10; i++) {
            list.Add(i);
            handles[i] = new ManualResetEvent(false);
        }
        for (int i = 0; i < 10; i++) {
            ThreadPool.QueueUserWorkItem(
             new WaitCallback(x =>
             {
                 Console.WriteLine(x);
                 handles[(int) x].Set();
             }), list[i]);
        }
        WaitHandle.WaitAll(handles);
