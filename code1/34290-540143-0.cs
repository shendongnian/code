    public static void SpawnAndWait(IEnumerable<Action> actions)
    {
        var list = actions.ToList();
        var handles = new ManualResetEvent[actions.Count()];
        for (var i = 0; i < list.Count; i++)
        {
            handles[i] = new ManualResetEvent(false);
            var currentAction = list[i];
            var currentHandle = handles[i];
            Action wrappedAction = () => { try { currentAction(); } finally { currentHandle.Set(); } };
            ThreadPool.QueueUserWorkItem(x => wrappedAction());
        }
        WaitHandle.WaitAll(handles);
    }
