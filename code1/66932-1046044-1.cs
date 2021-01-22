    this.workerLocker = new object(); // Global variable
    this.RunningWorkers = arrayStrings.Length; // Global variable
    
    foreach (string someString in arrayStrings)
    {
         ThreadPool.QueueUserWorkItem(this.DoSomething, someString);
         //Thread.Sleep(100);
    }
    
    // Waiting execution for all queued threads
    Monitor.Wait(this.workerLocker);
----------
    // Method DoSomething() definition
    public void DoSomething(object data)
    {
        // Do a slow process...
        // ...
        
        lock (this.workerLocker)
        {
            this.RunningWorkers--;
            if (this.RunningWorkers == 0)
               Monitor.Pulse(this.workerLocker);
        }
    }
