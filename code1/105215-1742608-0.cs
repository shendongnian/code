    using System.Threading;
    static void Main(string[] args)
    {
        ManualResetEvent processEvent = new ManualResetEvent(false);
        Thread thread = new Thread(delegate() {
            while (processEvent.WaitOne()) {
                performIO();
                processEvent.Reset(); // reset for next pass...
            }
        });
        thread.Name = "I/O Processing Thread"; // name the thread
        thread.Start();
    
        // Do GUI stuff...
    
        // When time to perform the IO processing, signal the event.
        processEvent.Set();
    }
