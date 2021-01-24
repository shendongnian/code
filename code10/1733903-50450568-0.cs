    class Program
    {
        static System.Threading.SemaphoreSlim Semaphore = new System.Threading.SemaphoreSlim(3, 3);
        static async Task F(int i)
        {
            Console.WriteLine($"F{i} starts on " + GetCurrentThreadId());
            await Semaphore.WaitAsync();
            Console.WriteLine($"F{i} continues on " + GetCurrentThreadId());
            await Task.Delay(6000);     //.ConfigureAwait(false); //<- uncomment to solve deadlock
            Console.WriteLine($"F{i} ends on " + GetCurrentThreadId());
            Semaphore.Release(1);
            //DeadLock();
        }
        static void DeadLock()
        {
            F(70).Wait();
        }
        static void Main(string[] args)
        {
            var context = new SingleThreadSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context); 
            for (int i = 0; i < 10; i++)
            {
                int ind = i;
                F(ind);
            }
            context.RunOnCurrentThread();
        }
        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();
    }
    
    sealed class SingleThreadSynchronizationContext : SynchronizationContext
    {
        
        private readonly Thread Thread = Thread.CurrentThread;
        
        public override void Post(SendOrPostCallback d, object state)
        {
            if (d == null)
                throw new ArgumentNullException("d");
            WorkItemsQueue.Add(new KeyValuePair<SendOrPostCallback, object>(d, state));
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException("Synchronously sending is not supported.");
        }
        
        public void RunOnCurrentThread()
        {
            foreach (var workItem in WorkItemsQueue.GetConsumingEnumerable())
                workItem.Key(workItem.Value);
        }
        
        public void Complete() { WorkItemsQueue.CompleteAdding(); }
    }
