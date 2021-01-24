    class ProducerConsumerQueue<T>
    {
        private readonly Queue<T> Queue = new Queue<T>();
    
        public void Add(T t)
        {
            lock (Queue)
            {
                Queue.Enqueue(t);
                if (Queue.Count == 1)
                {
                    // wake up one sleeper
                    Monitor.Pulse(Queue);
                }
            }
        }
    
        public bool TryTake(out T t, int millisecondsTimeout)
        {
            lock (Queue)
            {
                if (Queue.Count == 0)
                {
                    // try and wait for arrival
                    Monitor.Wait(Queue, millisecondsTimeout);
                }
                if (Queue.Count != 0)
                {
                    t = Queue.Dequeue();
                    return true;
                }
            }
            t = default(T);
            return false;
        }
    }
