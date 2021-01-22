     public void StopPoll()
            {
                MyBackgroundWorker.CancelAsync(); //Cancel background worker
                AutoResetEvent1.Set(); //Release delay so cancellation occurs soon
            }
     private void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                while (!MyBackgroundWorker.CancellationPending)
                {
                //Do some background stuff
                MyBackgroundWorker.ReportProgress(0, (object)SomeData);
                AutoResetEvent1.WaitOne(10000);
                }
        }
