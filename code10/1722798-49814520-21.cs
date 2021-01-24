    public class TasksToRun
    {
        private readonly BlockingCollection<TaskSettings> _tasks;
        public TasksToRun() => _tasks = new BlockingCollection<TaskSettings>();
        public void Enqueue(TaskSettings settings) => _tasks.Add(settings);
        public TaskSettings Dequeue(CancellationToken token) => _tasks.Take(token);
    }
