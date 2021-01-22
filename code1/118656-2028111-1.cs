    class TaskProcessor
    {
        AutoResetEvent newTaskHandle = new AutoResetEvent(false);
        Queue<Task> taskQueue = new Queue<Task>();
        object syncRoot = new object();
        public void ProcessTasks()
        {
            while (true)
            {
                newTaskHandle.WaitOne();
                Task task = null;
                lock (syncRoot)
                {
                    if (taskQueue.Count > 0)
                    {
                        task = taskQueue.Dequeue();
                    }
                }
                // Do task
            }
        }
        public void AddTask(Task task)
        {
            lock (syncRoot)
            {
                taskQueue.Enqueue(task);
                newTaskHandle.Set();
            }
        }
    }
