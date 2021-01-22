        public void LoadDataAsync()
        {
            ...
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += LoadChunk;
            bw.ProgressChanged += new ProgressChangedEventHandler(ChunkLoaded);
            bw.RunWorkerAsync();
        }
        void ChunkLoaded(object sender, ProgressChangedEventArgs e)
        {
           PopulateDataToUI();
        }
        private void LoadChunk(object sender, DoWorkEventArgs e)
        {
            int chunkNum = 0;
            BackgroundWorker bw = (BackgroundWorker)sender;
            bw.ReportProgress(chunkNum++);
            while (true)
            {
               ...   
               bw.ReportProgress(chunkNum++);
               if (done) then break;
            }
        }
