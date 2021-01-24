    public class Test
    {
        public static BlockingCollection<Action> Handlers = new BlockingCollection<Action>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Main (ThreadId = " + Thread.CurrentThread.ManagedThreadId + ")");
            var task = new TaskWrapper();
            task.CallBack += OnCallBack;
            task.Run();
            while (true)
            {
                var action = Handlers.Take();
                action();
            }
        }
       
        public static void OnCallBack(object sender, Action a)
        {
            Handlers.Add(a);
        }
    }
    public class TaskWrapper
    {
        public event EventHandler<Action> CallBack;
        public TaskWrapper()
        {
            CallBack += (sender, args) => { };
        }
        public void Run()
        {
            Task.Run(() =>
            {
                Console.WriteLine("RunTask (ThreadId = " + Thread.CurrentThread.ManagedThreadId + ")");
                
                CallBack(this, () => Console.WriteLine("CallBack (ThreadId = " + Thread.CurrentThread.ManagedThreadId + ")"));
                while (true)
                {
                }
            });
        }
    }
