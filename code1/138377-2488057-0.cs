    public enum JobStatus { Running, Completed, Failed };
    public class MyService : WebService
    {
        [WebMethod]
        public int BeginJob()
        {
            int id = GetJobID();
            // Save to a database or persistent data source
            SaveJobStatus(id, JobStatus.Running);
            ThreadPool.QueueUserWorkItem(s =>
            {
                // Do the work here
                SaveJobStatus(id, JobStatus.Completed);
            }
            return id;
        }
        [WebMethod]
        public JobStatus GetJobStatus(int id)
        {
            // Load the status from database or other persistent data source
            return ( ... )
        }
    }
