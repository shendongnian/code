    public class DoingProcessing
    {
        public Progress<int> HeavyTaskProgress { get; set; }
        private void Progress_ProgressChanged(object sender, int e)
        {
            string message = string.Format("progress at {0}%{1}", e, Environment.NewLine);
            System.IO.File.AppendAllText(@"d:\progress.txt", message);
        }
        public void DoProcessing()
        {
            HeavyTaskProgress = new Progress<int>();
            HeavyTaskProgress.ProgressChanged += Progress_ProgressChanged;
            DoProcessing(HeavyTaskProgress);
        }
        private void DoProcessing(IProgress<int> progress)
        {
            for (int i = 1; i <= 10; ++i)
            {
                Thread.Sleep(1000); // CPU-bound work
                if (progress != null)
                    progress.Report(i*10);
            }
        }
        public void ProcessingFinished(Task t)
        {
            System.IO.File.AppendAllText(@"d:\progress.txt", "Task done !! " + t.Status);
        }
        public DoingProcessing()
        {
        }
    } 
