    //using System.Threading;
    //the worker will ask this if it can run
    ManualResetEvent wh = new ManualResetEvent(false);
    //this holds UI state for the start/stop button
    bool canRun = false;
    private void StartBackgroundWorker()
    {
        bw = new BackgroundWorker();
        bw.WorkerReportsProgress = true;
        bw.WorkerSupportsCancellation = true;
        bw.DoWork += bw_DoWork;
        bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        bw.RunWorkerAsync("Background Worker");
    }
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
         //it waits here until someone calls Set() on wh  (via user input)
         // it will pass every time after that after Set is called until Reset() is called
         while(wh.WaitOne()) 
         {
              //do your work
              
         }
    }
    //background worker can't start until Set() is called on wh
    void btnStartStop_Clicked(object sender, EventArgs e)
    {
        //toggle the wait handle based on state
        if(canRun)
        {
            wh.Reset();
        }
        else {wh.Set();}
        canRun= !canRun;
        //btnStartStop.Text = canRun ? "Stop" : "Start";
    }
