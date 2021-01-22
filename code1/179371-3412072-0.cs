    public class JobQueue
    {
        private Queue<Exception> pendingJobs = new Queue<Exception>();
        private Exception defaultJob = null;
        bool run = true;
        public void AddJob(Exception job)
        {
            pendingJobs.Enqueue(job);
        }
        public JobQueue()
        {
            defaultJob=null;
        }
        public void StopJobQueue()
        {
            run = false;
        }
        
        public void Run()
        {
            while (run)
            {
                
                    Exception job = (pendingJobs.Count > 0) ? pendingJobs.Dequeue() : defaultJob;
                    
                    if (job!= null)
                    {
                      ////what to do with current Exception
                     }
                
                Thread.Sleep(20); //I know this is bad...
            }
            
            
            pendingJobs.Clear();
        }
    }
    }
