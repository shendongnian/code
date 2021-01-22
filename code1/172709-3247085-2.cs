    public static void WaitAll<T>(this List<T> list, TimeSpan timeout)
        where T : WaitHandle
    {
        var position = 0;
        while (position <= list.Count)
        {
            var chunk = list.Skip(position).Take(MaxWaitHandles);
            WaitHandle.WaitAll(chunk.ToArray(), timeout);
            position += MaxWaitHandles;
        }
    }
