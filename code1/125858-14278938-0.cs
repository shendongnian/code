    for (int i = 0; i < 999999; ++i)
    {
    
        // get sure to have valid highlighting
        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback((x) =>
        {
            while (backgroundWorker1.IsBusy && backgroundWorker2.IsBusy && backgroundWorker3.IsBusy && backgroundWorker4.IsBusy && backgroundWorker5.IsBusy)
            {
                System.Threading.Thread.Sleep(0);
            }
            // Code that is beging executed after threads have ended;
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
        else if (!backgroundWorker3.IsBusy)
        {
            backgroundWorker3.RunWorkerAsync();
        }
        else if (!backgroundWorker4.IsBusy)
        {
            backgroundWorker4.RunWorkerAsync();
        }
        else if (!backgroundWorker5.IsBusy)
        {
            backgroundWorker5.RunWorkerAsync();
        }
    }
    
