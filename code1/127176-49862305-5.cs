    [TestMethod]
    public void workerPoolTest()
    {
        WorkerPool<int> workerPool = new WorkerPool<int>(new CancellationTokenSource(), 5);
        workerPool.startWorkers(value =>
        {
            log.Debug(value);
        });
        for (int i = 0; i < 100; i++)
        {
            workerPool.enqueue(i);
        }
        workerPool.CompleteAdding();
        workerPool.await();
    }
