    public static class Scheduler
    {
        private const long TimerGranularity = 100;
         
        static Scheduler()
         {
             ScheduleTimer = new Timer(Callback, null, Timeout.Infinite, Timeout.Infinite);
            Tasks = new SortedQueue<Task>();
         }
        private static void Callback(object state)
        {
            var first = Tasks.Peek();
            if(first.ExecuteAt<DateTime.Now)
            {
                Tasks.Dequeue();
                var executionThread = new Thread(() => first.Function());
                executionThread.Start();                
            }
        }
        private static Timer ScheduleTimer { get; set; }
        public static void Start()
        {
            ScheduleTimer.Change(0, TimerGranularity);
        }
        public static void Add(Task task)
        {
            Tasks.Enqueue(task);
        }
        public static SortedQueue<Task> Tasks { get; set; }
    }
    public class Task : IComparable<Task>
    {
        public Func<Boolean> Function { get; set; }
        public DateTime ExecuteAt { get; set; }
        public int CompareTo(Task other)
        {
            return ExecuteAt.CompareTo(other.ExecuteAt);
        }
    }
