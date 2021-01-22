    public class SignaledQueue<T>
    {
        Queue<T> queue = new Queue<T>();
        volatile bool shutDown = false;
        public bool Enqueue(T item)
        {
            if (!shutDown)
            {
                lock (queue)
                {
                    queue.Enqueue(item);
                    //Pulse only if there can be waiters.
                    if (queue.Count == 1)
                    {
                        Monitor.PulseAll(queue);
                    }
                }
                return true;
            }
            //Indicate that processing should stop.
            return false;
        }
        public IEnumerable<T> DequeueAll()
        {
            while (!shutDown)
            {
                do
                {
                    T item;
                    lock (queue)
                    {
                        //If the queue is empty, wait.
                        if (queue.Count == 0)
                        {
                            if (shutDown) break;
                            Monitor.Wait(queue);
                            if (queue.Count == 0) break;
                        }
                        item = queue.Dequeue();
                    }
                    yield return item;
                } while (!shutDown);
            }
        }
        public void SignalShutDown()
        {
            shutDown = true;
            lock (queue)
            {
                //Signal all waiting consumers with PulseAll().
                Monitor.PulseAll(queue);
            }
        }
    }
