    public ProcessFilesClass()
        {
            InitializeComponent();
            backgroundWorker1= new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var backgroundWorker = sender as BackgroundWorker;
            worker.WorkerReportsProgress = true;
			WorkerProcessMethod();
        }
    private void WorkerProcessMethod()
		{
				//Process items in list box
				int itemsToProcess = someListBox.Items.Count;
				for (int i = 0; i < itemsToProcess; i++)
                    {
                        int findPercentage = ((i + 1) * 100) / someListBox.Items.Count;
                         if (backgroundWorker1 != null) { backgroundWorker1.ReportProgress(findPercentage, null); }
                    }
		}
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
               progressBar1.Value = e.ProgressPercentage;
        }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
              //DisableProgressBarStatus
               this.Close();            
        }
