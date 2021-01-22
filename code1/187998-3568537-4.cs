    public class ConcurrentQueue<T>:IEnumerable<T>
    {
        volatile bool fFinished = false;
        ManualResetEvent eventAdded = new ManualResetEvent(false);
        private Queue<T> queue = new Queue<T>();
        private object syncRoot = new object();
        public void SetFinished()
        {
            lock (syncRoot)
            {
                fFinished = true;
                eventAdded.Set();
            }
        }
        public void Enqueue(T t)
        {
            Debug.Assert (false == fFinished);
            lock (syncRoot)
            {
                queue.Enqueue(t);
                eventAdded.Set();
            }
        }
        private bool Dequeue(out T t)
        {
            do
            {
                lock (syncRoot)
                {
                    if (0 < queue.Count)
                    {
                        t = queue.Dequeue();
                        return true;
                    }
                    if (false == fFinished)
                    {
                        eventAdded.Reset ();
                    }
                }
                if (false == fFinished)
                {
                    eventAdded.WaitOne();
                }
                else
                {
                    break;
                }
            } while (true);
            t = default(T);
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            T t;
            while (Dequeue(out t))
            {
                yield return t;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
