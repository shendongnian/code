    static void Main(string[] args)
    {
    	BackgroundWorker worker = new BackgroundWorker();
    
    	worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
    	worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
    	worker.WorkerReportsProgress = true;
    	worker.WorkerSupportsCancellation = false;
    	worker.DoWork += new DoWorkEventHandler(MyThreadMethod);
    	worker.RunWorkerAsync();
    	Console.Read();
    }
    
    static void MyThreadMethod(object sender, DoWorkEventArgs e)
    {
    	Console.WriteLine("Worker starts working.");
    	for (int i = 1; i <= 100; i++)
    	{
    		((BackgroundWorker)sender).ReportProgress(i);
    	}
    	Console.WriteLine("Worker works fine.");
    }
    
    static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	Console.WriteLine("Worker has finished.");
    }
    
    static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	Console.WriteLine("Worker reports progress {0}", e.ProgressPercentage);
    }
