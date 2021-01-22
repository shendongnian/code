    public static Queue<TimeSpan> CompressTimeSpan(Queue<TimeSpan> original, int interval)
    {
        Queue<TimeSpan> newQueue = new Queue<TimeSpan>();
        if (original.Count == 0) return newQueue;
        int current = 0;
        TimeSpan runningTotal = TimeSpan.Zero;
        TimeSpan currentTimeSpan = original.Dequeue();
        while (original.Count > 0 && current < interval)
        {
            runningTotal += currentTimeSpan;
            if (++current >= interval)
            {
                newQueue.Enqueue(TimeSpan.FromTicks(runningTotal.Ticks / interval));
                runningTotal = TimeSpan.Zero;
                current = 0;
            }
            currentTimeSpan = original.Dequeue();
        }
        if (current > 0)
            newQueue.Enqueue(TimeSpan.FromTicks(runningTotal.Ticks / current));
        return newQueue;
    }
