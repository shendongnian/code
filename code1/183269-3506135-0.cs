    class MyClass
    {
        BackgroundWorker bgWorker = new BackgroundWorker();
       
        public MyClass()
        {
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += 
                new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.WorkerReportsProgress = true;
            this.Drop += new DragEventHandler(Dropaudio);
        }
    
        private void Dropaudio(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] droppedFilePaths = 
                    e.Data.GetData(DataFormats.FileDrop, true) as string[];
                List<string> Jobs = new List<string>(droppedFilePaths);
                bgWorker.RunWorkerAsync(Jobs);
            }
        }
    
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                Addingcues.Visibility = Visibility.Visible;
            }
            addcuepath.Text = e.UserState.ToString;
        }
    
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] Jobs = e.Argument as string[];
            bgWorker.ReportProgress(0, "Processing Data");
            double count = 0;
            double total = Jobs.Count;
            foreach (string droppedFilePath in Jobs)
            {                
                if (System.IO.Path.GetExtension(droppedFilePath) == ".mp3" || 
                    System.IO.Path.GetExtension(droppedFilePath) == ".wav" || 
                    System.IO.Path.GetExtension(droppedFilePath) == ".flac")
                {
                    double pct = count / total;
                    // Report this file
                    bgWorker.ReportProgress((int) (pct * 100), droppedFilePath);
                    var provider = (XmlDataProvider)this.Resources["CUEData"];
                    XmlDocument xmlcuelijst = provider.Document;
                    // Do other stuff from above
                    count += 1;
                }
            }
    
        }
    
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Addingcues.Visibility = Visibility.Hidden;
        }       
    }
