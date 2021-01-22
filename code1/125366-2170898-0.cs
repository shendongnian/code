    public bool TryEnqueue(T item)
    {
        lock (queue)
        {
            if (queue.Count >= maxSize) { return false; }
            queue.Enqueue(item);
            if (queue.Count == 1)
            {
                // wake up any blocked dequeue
                Monitor.PulseAll(queue);
            }
            return true;
        }
    }
