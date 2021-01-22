      public class Program
      {
        public static void Main(string[] args)
        {
          List<TestJob> jobList = new List<TestJob>();
    
          jobList.Add(new TestJob() { ID = 1 });
          jobList.Add(new TestJob() { ID = 2 });
          jobList.Add(new TestJob() { ID = 3 });
          jobList.Add(new TestJob() { ID = 4 });
    
          CalcuateEstimatedExecutionTimesForDueJobs(jobList);
    
          foreach (TestJob job in jobList)
          {
            Console.WriteLine("{0} {1} {2}", job.ID, job.StartDate, job.FinishedDate);
          }
          Console.ReadLine();
        }
    
        private static void CalcuateEstimatedExecutionTimesForDueJobs(List<TestJob> dueJobs)
        {
          DateTime rollingTime = DateTime.Now;
    
          foreach (TestJob job in dueJobs)
          {
            job.SetEstimatedStart(rollingTime);
    
            double estimatedRuntime = job.GetEstimatedRuntime();
            rollingTime = rollingTime.AddSeconds(estimatedRuntime);
    
            job.SetEstimatedFinish(rollingTime);
          }
        }
      }
    
      public class TestJob
      {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public void SetEstimatedStart(DateTime date)
        {
          this.StartDate = date;
        }
        public void SetEstimatedFinish(DateTime date)
        {
          this.FinishedDate = date;
        }
    
        public double GetEstimatedRuntime()
        {
          return 35;
        }
    
      }
