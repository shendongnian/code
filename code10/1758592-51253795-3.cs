    public class TaskTracker
    {
        public TaskDict Tasks = new TaskDict();
        public TaskTracker()
        {
            // You could add tasks here if needed
            Tasks.Add(MyTasks.taskName5, new Task("the fifth task"));
            // Or remove them:
            Tasks.Remove(MyTasks.taskName1);
        
            _run();
        }
        private void _run()
        {
            foreach(MyTasks t in Tasks.Keys)
            {
                Tasks[t].PrintName();
            }
        }
    }
