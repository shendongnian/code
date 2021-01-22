    var signal = new object();
    var signalSet = false;
    // Thread 1
    lock (signal)
    {
        while (!signalSet)
        {
            Monitor.Wait(signal);
        }
    }
    // Thread 2
    lock (signal)
    {
        signalSet = true;
        Monitor.Pulse(signal);
    }
