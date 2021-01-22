    if (BckgrndWrkr == null)
    {
        BckgrndWrkr = new BackgroundWorker(); 
        BckgrndWrkr.DoWork += DoWorkMethod;
        BckgrndWrkr.RunWorkerAsync();     
    }
    else if (!BckgrndWrkr.IsBusy)
    {
        BckgrndWrkr.RunWorkerAsync();
    }
