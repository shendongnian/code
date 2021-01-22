    volatile bool closing;
    public void Close()
    {
        closing = true;
    }
    public bool TryDequeue(out T value)
    {
        lock (queue)
        {
            while (queue.Count == 0)
            {
                if (closing)
                {
                    value = default(T);
                    return false;
                }
                Monitor.Wait(queue);
            }
            value = queue.Dequeue();
            if (queue.Count == maxSize - 1)
            {
                // wake up any blocked enqueue
                Monitor.PulseAll(queue);
            }
            return true;
        }
    }
