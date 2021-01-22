    public static void RemoveAt<T>(this Queue<T> queue, int index)
    {
        Contract.Requires(queue != null);
        Contract.Requires(index >= 0);
        Contract.Requires(index < queue.Count);
        
        var i = 0;
        
        // Move all the items before the one to remove to the back
        for (; i < index; ++i)
        {
            queue.MoveHeadToTail();
        }
        
        // Remove the item at the index
        queue.Dequeue();
        
        // Move all subsequent items to the tail end of the queue.
        var queueCount = queue.Count;
        for (; i < queueCount; ++i)
        {
            queue.MoveHeadToTail();
        }
    }
