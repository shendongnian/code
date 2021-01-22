    private void PerformLongRunningOperation()
        {
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate
                                 {
                                     // perform long running operation here 
                                 };
                worker.RunWorkerAsync();
            }
        }
