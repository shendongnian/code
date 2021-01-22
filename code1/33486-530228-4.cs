    bool closing;
    public void Close()
    {
        lock(queue)
        {
            closing = true;
            Monitor.PulseAll(queue);
        }
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
