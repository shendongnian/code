    public class TheClass
    {
        private Thread m_Thread;
        private BlockingCollection<object> m_Queue = new BlockingCollection<object>();
        private CancellationTokenSource m_Cancellation = new CancellationTokenSource();
    
        public void Start()
        {
            m_Thread = new Thread(new ThreadStart(Run));
            m_Thread.IsBackground = true;
            m_Thread.Start();
        }
    
        private void Run()
        {
            while (true)
            {
                try
                {
                    object job = m_Queue.Take(m_Cancellation.Token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
    
        public void AddJob(object param)
        {
            m_Queue.Add(param);
        }
    
        public void Stop()
        {
            m_Cancellation.Cancel();
            m_Thread.Join();
        }
    }
