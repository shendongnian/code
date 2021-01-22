    private void btnCopyFiles_Click(object sender, EventArgs e)
    {
        InitializeBackgroundWorker();
    
        CopyStruct copyStruct = new CopyStruct
        {
            sourceDir = @"C:\folder1\",
            destDir = @"C:\folder2\"
        };
    
        backgroundWorker.RunWorkerAsync(copyStruct);
    }
    
    private void InitializeBackgroundWorker()
    {
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.DoWork += backgroundWorker_DoWork;
        backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
    }
    
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;
    }
    
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // do something when finished
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker) sender;
        CopyStruct copyStruct = (CopyStruct) e.Argument;
    
        DirectoryInfo di = new DirectoryInfo(copyStruct.sourceDir);
        FileInfo[] filelist = di.GetFiles("*.*");
        
        int numFiles = filelist.Length;
    
        for (int i = 0; i < numFiles; i++)
        {
            FileInfo file = filelist[i];
    
            File.Copy(Path.Combine(copyStruct.sourceDir, file.Name), Path.Combine(copyStruct.destDir, file.Name), true);
            // This line updates the progress bar
            worker.ReportProgress((int) ((float) i/numFiles*100));
        }
    }
