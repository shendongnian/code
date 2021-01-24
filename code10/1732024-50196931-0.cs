    class Program
    {
        private static BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
        private static AutoResetEvent resetEvent = new AutoResetEvent(false);
    	private string[] files;
        static void Main(string[] args)
        {
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
    
            Console.WriteLine("Starting Application...");
    
            worker.RunWorkerAsync();
            resetEvent.WaitOne();
    
            Console.ReadKey();
        }
    
        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage.ToString());
        }
    
        static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            files = GetFiles(@"C:\filesystem"); ///100 files here
    
            resetEvent.Set();
        }
    
        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach(string filename in files) {
    
    		}
        }
    
    }
