    boolean volatile isRunning = true;
    
    static void Main(...)
    {
        // ...
        // Working
        for (i = 0; i <= 10000; i++)
        {
            semaphore.WaitOne();
            if (!isRunning) break; // exit if not running
            if (pBar.Running)
                bgworker_ProgressChanged(i);
            semaphore.Release();
        }
        //...
        t1.Interrupt();// make the worker thread catch the exception
    }
    // 
    void cancelButton_Click(object sender, EventArgs e)
    {
        isRunning = false; // optimistic stop
        semaphore.Release();
    }
