    using System.Collections.Generic;
    
    class Example
    {
        private readonly object _lock = new object();
    
        bool IsDepleted
        {
            get
            {
                lock (_lock)
                {
                    return WaitingQueue.Count == 0
                     && Processing.Count == 0;
                }
            }
        }
    
        private readonly List<object> Processing = new List<object>();
        private readonly Queue<object> WaitingQueue = new Queue<object>();
    
        public void MethodA(object item)
        {
            lock (_lock)
            {
                if (WaitingQueue.Count > 0)
                {
                    if (StartItem(WaitingQueue.Peek()))
                    {
                        WaitingQueue.Dequeue();
                    }
                }
            }
        }
    
        public void MethodB(object identifier)
        {
            lock (_lock)
            {
                Processing.Remove(identifier);
                if (!IsDepleted)
                {
                    return;
                }
            }
            //Do something...
        }
    
        bool StartItem(object item)
        {
            //Do something and return a value
        }
    }
