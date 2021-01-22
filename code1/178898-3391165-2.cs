        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        bw.WorkerReportsProgress = true;
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // update UI with status
            label1.Text = (string)e.UserState
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             //Check for cancel
             if(e.Cancelled)
             { 
                 //Handle the cancellation.
             {
             //Check for error
             if(e.Error)
             {
                 //Handle the error.
             }    
            // Update UI that data retrieval is complete
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get data
            //foreach to process data
            //Report progress
            bw.ReportProgress(n, message);
        }
