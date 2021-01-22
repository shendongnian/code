        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            
            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;
            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;
                    // do some simple processing for 10 seconds
                    for (int i = 1; i <= 10; i++)
                    {
                        // report the progress in percent
                        b.ReportProgress(i * 10);
                        Thread.Sleep(1000);
                    }
                    
                });
            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
                delegate(object o, ProgressChangedEventArgs args)
                {
                    label1.Text = string.Format("{0}% Completed", args.ProgressPercentage);
                });
            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    label1.Text = "Finished!";
                });
            bw.RunWorkerAsync();
        }
