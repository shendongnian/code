    for (int i = 0; i < 100; i++)
    {
        var count = i;
        taskArray.Add(Task.Factory.StartNew((Object obj) => {
            int j = 0 + count;
            cb.Add(j);
            Debug.WriteLine("Task #{0} created on {1}",
                                j, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10);
        },
                                                i));
    }
