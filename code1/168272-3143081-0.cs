    System.Timers.Timer consumerTimer;
    Queue<byte[]> queue = new Queue<byte[]>();
    
    void Producer()
    {
        consumerTimer = new System.Timers.Timer(1000);
        consumerTimer.Elapsed += new System.Timers.ElapsedEventHandler(consumerTimer_Elapsed);
        while (true)
        {
            magic.BlockUntilMagicAvailable();
            lock (queue)
            {
                queue.Enqueue(magic.Produce());
                if (!consumerTimer.Enabled)
                {
                    consumerTimer.Start();
                }
            }
        }
    }
    
    void consumerTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        while (true)
        {
            consumerTimer.Stop();
            lock (queue)
            {
                if (queue.Count > 0)
                {
                    DoSomething(queue.Dequeue());
                }
                else
                {
                    break;
                }
            }
        }
    }
