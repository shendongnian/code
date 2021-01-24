    class Scheduler : TaskScheduler
    {
        protected override void QueueTask(Task task) => 
            Console.WriteLine("QueueTask");
    
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            Console.WriteLine("TryExecuteTaskInline");
    
            return false;
        }
    
        protected override IEnumerable<Task> GetScheduledTasks() => throw new NotImplementedException();
    }
    
    static class Program
    {
        static void Main()
        {
            var taskToStart = new Task(() => { });
            var taskToRunSynchronously = new Task(() => { });
    
            taskToStart.Start(new Scheduler());
            taskToRunSynchronously.RunSynchronously(new Scheduler());
        }
    }
