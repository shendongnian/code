    [Test]
    public void Can_add_from_multiple_threads()
    {
        const int MaxWorkers = 10;
        var list = new ThreadSafeList<int>(MaxWorkers);
        int remainingWorkers = MaxWorkers;
        var workCompletedEvent = new ManualResetEvent(false);
        for (int i = 0; i < MaxWorkers; i++)
        {
            int workerNum = i;  // Make a copy of local variable for next thread
            ThreadPool.QueueUserWorkItem(s =>
            {
                list.Add(workerNum);
                if (Interlocked.Decrement(ref remainingWorkers) == 0)
                    workCompletedEvent.Set();
            });
        }
        workCompletedEvent.WaitOne();
        workCompletedEvent.Close();
        for (int i = 0; i < MaxWorkers; i++)
        {
            Assert.IsTrue(list.Contains(i), "Element was not added");
        }
        Assert.AreEqual(MaxWorkers, list.Count,
            "List count does not match worker count.");
    }
