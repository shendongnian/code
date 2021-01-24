    public class BigStackTaskScheduler : TaskScheduler
    {
        private int _stackSize;
        public BigStackTaskScheduler(int stackSize)
        {
            _stackSize = stackSize;
        }
        // we don't need to keep a tasks queue here
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return new Task [] { };
        }
        protected override void QueueTask(Task task)
        {
            var thread = new Thread(ThreadWork, _stackSize);
            thread.Start(task);
        }
        // we aren't going to inline the execution
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            QueueTask(task);
            return false;
        }
        private void ThreadWork(object obj)
        {
            if (obj is Task task)
                TryExecuteTask(task);
        }
    }
    class Program
    {
        async static Task Test()
        {
            var taskFactory = new TaskFactory(
                CancellationToken.None, TaskCreationOptions.DenyChildAttach,
                TaskContinuationOptions.None, new BigStackTaskScheduler(0xffff * 2));
            await taskFactory.StartNew(() => { Console.WriteLine("Task"); });
        }
        static void Main(string[] args)
        {
            Test().Wait();
        }
    }
