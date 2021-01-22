    internal static IEnumerable<ApplicationTask> ApplicationTaskIterator(SessionMetrics sm)
    {
        lock (ThreadMetrics._allThreadMetrics)
        {
            foreach (var tm in ThreadMetrics._allThreadMetrics.Values)
            {
                ApplicationTask currentTask;
                if ((tm._managedThread.ThreadState == ThreadState.Stopped) ||
                    object.ReferenceEquals(tm, Thread.CurrentThread) ||
                    ((currentTask = tm.CurrentApplicationTask) == null) ||
                    ((sm != null) && currentTask.CurrentSessionMetrics.SessionGUID.Equals(sm.SessionGUID))))
                {
                    continue;
                }
                currentTask.Active = !tm.Suspended;
                yield return currentTask;
            }
        }
    }
