    public class MyParallelJobContainer
    {
        private readonly IList<IJob> parallelJobs = new List<IJob>();
        
        public MyParallelJobContainer()
        {
            this.progress = progress;
        }
        public void Add(IJob job) { ... }
        void RunJobs(IProgress<MyProgress> progress, Action<IJob>? callback = null)
        {
            using (var progressBar = new ProgressBar(options...))
            {
                Parallel.ForEach(parallelJobs, job =>
                {
                    callback?.Invoke(job);
                    job.Execute();
                    progressBar.Tick();
                })
            }
        }
    }
