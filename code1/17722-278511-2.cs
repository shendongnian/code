    public class TaskExceptionList : Exception
    {
        public List<Exception> TaskExceptions { get; set; }
        public TaskExceptionList()
        {
            TaskExceptions = new List<Exception>();
        }
    }
        public void DoTasks(MyTask[] taskList)
        {
            TaskExceptionList log = new TaskExceptionList();
            foreach (MyTask task in taskList)
            {
                try
                {
                    DoTask(task);
                }
                catch (Exception ex)
                {
                    log.TaskExceptions.Add(ex);
                }
            }
            if (log.TaskExceptions.Count > 0)
            {
                throw log;
            }
        }
