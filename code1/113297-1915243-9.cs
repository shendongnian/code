    public class ThreadPoolWorker
    {
        private IJob job;
        private ManualResetEvent doneEvent;
        public ThreadPoolWorker(IJob job, ManualResetEvent doneEvent)
        {
            this.job = job;
            this.doneEvent = doneEvent;
        }
        public void ThreadPoolCallback(object state)
        {
            try
            {
                job.Execute();
            }
            finally
            {
                doneEvent.Set();
            }
        }
    }
