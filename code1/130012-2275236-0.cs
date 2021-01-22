    Timer queueTimer = new Timer(QueueTimerProc, null, 20, 20);
    queueTimer.Start();
    
    void QueueTimerProc(object state)
    {
        if (queue.Count > 0)
        {
            if (this.InvokeRequired)
               // Invoke the EmptyQueue method 
            else
               // Call the EmptyQueue method
        }
    }
    
    void EmptyQueue()
    {
        lock (queue)
        {
            while (queue.Count > 0)
            {
                // dequeue an item and post the update
            }
        }
    }
