    static void Main(string[] args)
    {
        CountDownLatch latch = new CountDownLatch(numFiles);
        // 
        // ...
        // 
        putFileWorker("blah", streamContent);
        // 
        // ...
        // 
        // waits for all of the threads to signal
        latch.Wait();
    }
