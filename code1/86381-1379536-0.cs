    private delegate void StartDNIThreadDelegate(string storeID, string queryObject);
    private static void Main()
    {
        string storeID = "...";
        string queryObject = "...";
        StartDNIThreadDelegate startDNIThread = new StartDNIThreadDelegate(StartDNIThread);
        IAsyncResult result = startDNIThread.BeginInvoke(storeID, queryObject, new AsyncCallback(StartDNIThreadDone), startDNIThread);
        // Do non-threaded stuff...
        result.AsyncWaitHandle.WaitOne(); // wait for thread to finish.
    }
    private static void StartDNIThread(string storeID, string queryObject)
    {
        // Do StartDNIThreading stuff.
    }
    private static void StartDNIThreadDone(IAsyncResult result)
    {
        StartDNIThreadDelegate startDNIThread = (StartDNIThreadDelegate)result.AsyncState;
        startDNIThread.EndInvoke(result);
        // Do after thread finished cleanup.
    }
