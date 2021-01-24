    public class Job
    {
        private readonly TimeSpan timeForJobToTake;
        public Job(TimeSpan timeForJobToTake)
        {
            this.timeForJobToTake = timeForJobToTake;
        }
        public void DoJob()
        {
            DateTime endTime = DateTime.UtcNow.Add(this.timeForJobToTake);
            while (DateTime.UtcNow < endTime)
            {
                // emulate high CPU load during job
            }
        }
    }
    public class WorkObject
    {
        private readonly List<Job> jobs = new List<Job>();
        public WorkObject(Random random)
        {
            int jobsToCreate = random.Next(1, 10);
            for (int i = 0; i < jobsToCreate; i++)
            {
                Job job = new Job(TimeSpan.FromMilliseconds(random.Next(100, 200)));
                this.jobs.Add(job);
            }
        }
        public int JobCount => this.jobs.Count;
        public void PerformWork()
        {
            foreach (Job job in this.jobs)
            {
                job.DoJob();
            }
        }
    }
