    var signal = new object();
    // Thread 1
    lock (signal)
    {
        Monitor.Wait(signal);
    }
    // Thread 2
    lock (signal)
    {
        Monitor.Pulse(signal);
    }
