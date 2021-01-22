    public static Queue<TimeSpan> CompressTimeSpan(Queue<TimeSpan> original, int interval)
    {
        Queue<TimeSpan> newQueue = new Queue<TimeSpan>();
        int current = 0;
        TimeSpan runningTotal = TimeSpan.Zero;
        TimeSpan currentTimeSpan = original.Dequeue();
        while (currentTimeSpan != default(TimeSpan) && current < interval)
        {
            runningTotal += currentTimeSpan;
            if (++current >= interval)
            {
                newQueue.Enqueue(TimeSpan.FromTicks(runningTotal.Ticks / interval));
                runningTotal = TimeSpan.Zero;
                current = 0;
            }
        }
        if (current > 0)
            newQueue.Enqueue(TimeSpan.FromTicks(runningTotal.Ticks / current));
        return newQueue;
    }
