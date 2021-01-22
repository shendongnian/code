    public class Synchronizer : ISynchronizeInvoke
    {
        private Thread m_Thread;
        private BlockingCollection<Message> m_Queue = new BlockingCollection<Message>();
    
        public Synchronizer()
        {
            m_Thread = new Thread(Run);
            m_Thread.IsBackground = true;
            m_Thread.Start();
        }
    
        private void Run()
        {
            while (true)
            {
                Message message = m_Queue.Take();
                message.Return = message.Method.DynamicInvoke(message.Args);
                message.Finished.Set();
            }
        }
    
        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            Message message = new Message();
            message.Method = method;
            message.Args = args;
            m_Queue.Add(message);
            return message;
        }
    
        public object EndInvoke(IAsyncResult result)
        {
            Message message = result as Message;
            if (message != null)
            {
                message.Finished.WaitOne();
                return message.Return;
            }
            throw new ArgumentException("result");
        }
    
        public object Invoke(Delegate method, object[] args)
        {
            Message message = new Message();
            message.Method = method;
            message.Args = args;
            m_Queue.Add(message);
            message.Finished.WaitOne();
            return message.Return;
        }
    
        public bool InvokeRequired
        {
            get { return Thread.CurrentThread != m_Thread; }
        }
    
        private class Message : IAsyncResult
        {
            public Delegate Method = null;
            public object[] Args = null;
            public object Return = null;
            public object State = null;
            public ManualResetEvent Finished = new ManualResetEvent(false);
    
            public object AsyncState
            {
                get { return State; }
            }
    
            public WaitHandle AsyncWaitHandle
            {
                get { return Finished; }
            }
    
            public bool CompletedSynchronously
            {
                get { return false; }
            }
    
            public bool IsCompleted
            {
                get { return Finished.WaitOne(0); }
            }
        }
    }
