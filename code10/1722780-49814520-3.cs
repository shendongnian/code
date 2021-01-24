    public class TasksToRun
    {
        private readonly BlockingCollection<TaskSettings> _tasks;
        public TasksToRun() => _tasks = new BlockingCollection<TaskSettings>();
        public Enqueue(TaskSettings settings) => _tasks.Enqueue(settings);
        public Dequeue() => _tasks.Dequeue();
    }
