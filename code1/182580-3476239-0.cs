        public delegate void DoWorkDelegate(object sender,DoWorkEventArgs e);
 
         public void GetUpdates()
         {
             StartWorker(new DoWorkDelegate(updateWorker_DoWork));
         }
 
         public void StartWorker(DoWorkDelegate task)
         {
             //Set up worker
             updateWorker.WorkerReportsProgress = true;
             updateWorker.WorkerSupportsCancellation = true;
             updateWorker.DoWork += new DoWorkEventHandler(task);
             updateWorker.RunWorkerCompleted +=
                 new RunWorkerCompletedEventHandler(updateWorker_RunWorkerCompleted);
             updateWorker.ProgressChanged +=
                 new ProgressChangedEventHandler(updateWorker_ProgressChanged);
 
             //Run worker
             _canCancelWorker = true;
             updateWorker.RunWorkerAsync();
             //Initial Progress zero percent event
             _thes.UpdateProgress(0);
         }
   
          private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
          {
              BackgroundWorker worker = sender as BackgroundWorker;
              e.Result = GetUpdatesTask(worker, e);
          }
