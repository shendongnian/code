    for (int i = 0; i < 999999; ++i)
    {
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback((x) =>
        {
            while (backgroundWorker1.IsBusy && backgroundWorker2.IsBusy)
            {
                System.Threading.Thread.Sleep(0);
            }
            // Code that is beging executed after all threads have ended. 
            myCode();
        }));
    
        if (!backgroundWorker1.IsBusy)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        else if (!backgroundWorker2.IsBusy)
        {
            backgroundWorker2.RunWorkerAsync();
        }        
    }
    
