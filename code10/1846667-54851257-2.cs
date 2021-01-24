    public class MyService : IMyService
    {
        private readonly IJobContainer sequentialJobs;
        private readonly IJobContainer parallelJobs;
    
        public MyService(
            IJobContainer sequentialJobs,
            IJobContainer parallelJobs)
        {
            this.sequentialJobs = sequentialJobs;
            this.parallelJobs = parallelJobs;
            this.sequentialJobs.Add(new DoSequentialJob1());
            this.sequentialJobs.Add(new DoSequentialJob2());
            this.sequentialJobs.Add(new DoSequentialJob3));
            this.parallelJobs.Add(new DoParallelJobA());
            this.parallelJobs.Add(new DoParallelJobB());
            this.parallelJobs.Add(new DoParallelJobC());
        }
        public void RunJobs(IProgress<MyCustomProgress> progress)
        {
            sequentialJobs.RunJobs(progress, job => 
            {
                 // do something with the job if necessary
            });
            parallelJobs.RunJobs(progress, job => 
            {
                 // do something with the job if necessary
            });
        }
