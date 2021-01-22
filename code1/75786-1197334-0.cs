        private void WhereBackworkerStarts()
        {
            backgroundWorker.WorkerSupportsCancellation = true;
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
            else
                backgroundWorker.RunWorkerAsync();
        }
        // Events
        static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < int.MaxValue; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                // Do work here
            }
            e.Result = MyResult;
        }
        static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Deal with results
        }
