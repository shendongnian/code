    var events = new ManualResetEvent[10];
    var list = new List<int>();
    for (int i = 0; i < 10; i++) list.Add(i);
    for (int i = 0; i < 10; i++)
    {
        events[i] = new ManualResetEvent(false);
        int j = i;
        ThreadPool.QueueUserWorkItem(x => {
            Console.WriteLine(x);
            events[j].Set();
        }, list[i]);
    }
    WaitHandle.WaitAll(events);
