        /// <summary>
        /// Used to prevent more than one worker.
        /// </summary>
        private bool working = false;
        /// <summary>
        /// Must use a lock to synch between UI thread and worker thread.
        /// </summary>
        private object stateLock = new object();
        /// <summary>
        /// Used to pass custom args into the worker function.
        /// </summary>
        private class Data
        {
            public string query;
            public string[] values;
        }
        /// <summary>
        /// Called in your UI thread in response to button press.
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="Values"></param>
        public void UiRequestToDoWork(string Query, params string[] Values)
        {
            lock (stateLock)
            {
                if (working)
                {
                    // Do nothing!
                    Trace.WriteLine("Already working!");
                }
                else
                {
                    var backgroundWorker = new System.ComponentModel.BackgroundWorker();
                    backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_DoWork);
                    backgroundWorker.RunWorkerAsync(new Data { query = Query, values = Values });
                    this.working = true;
                }
            }
        }
        /// <summary>
        /// Does all the background work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Data data = e.Argument as Data;
                if (data != null)
                {
                    // Do your query in here - just simulating work with a sleep.
                    Trace.WriteLine("Working...");
                    System.Threading.Thread.Sleep(500);
                    // Note: you can't access the UI directly here in the worker thread. Use
                    // Form.Invoke() instead to update the UI after your work is done.
                }
            }
            finally
            {
                // Note the use of finally to be safe if exceptions get thrown.
                lock (stateLock)
                {
                    this.working = false;
                }
                Trace.WriteLine("Finished!");
            }
        }
