    //using System.Collections.Generic;
    //using System.Threading;
    private static volatile int numRunning = 2;
    private static volatile int spinLock = 0;
    static void Main(string[] args)
    {
        new Thread(TryWrite).Start();
        new Thread(TryWrite).Start();
    }
    static void TryWrite()
    {
        while(true) 
        {
            for (int i = 0; i < 1000000; i++ )
            {
                Create(i.ToString());
            }
            Interlocked.Decrement(ref numRunning);
            while (numRunning > 0) { } // make sure every thread has passed the previous line before proceeding (call this barrier 1)
            while (Interlocked.CompareExchange(ref spinLock, 1, 0) != 0){Thread.Sleep(0);} // Aquire lock (spin lock)
            // only one thread can be here at a time...
            if (numRunning == 0) // only the first thread to get here executes this...
            {
                numRunning = 2; // resets barrier 1
                // since the other thread is beyond the barrier, but is waiting on the spin lock,
                //  nobody is accessing the cache, so we can clear it...
                _cache = new Dictionary<string, object>(); // clear the cache... 
            }
            spinLock = 0; // release lock...
        }
    }
