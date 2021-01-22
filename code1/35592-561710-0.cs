    public class User
    {
        private Dictionary<string,Task> tasks;
        internal Dictionary<string,Task> Tasks
        {
          get { return tasks; }
          set { tasks = value; }
        }
        internal void AddTask(Task task)
        {
            tasks.Add(task.Task_Call_ID,task);
        }
        internal void AddTasks(List<Task> task)
        {
            foreach(Task task in Tasks)
            {
                tasks.Add(task.Task_Call_ID,task);
            }
        }
    }
