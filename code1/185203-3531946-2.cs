    internal static IEnumerable<ApplicationTask> ApplicationTaskIterator(SessionMetrics sm)
    {
        lock (ThreadMetrics._allThreadMetrics)
        {
            foreach (var tm in ThreadMetrics._allThreadMetrics.Values)
            {
                if (tm._managedThread.ThreadState != ThreadState.Stopped)
                {
                    if (!object.ReferenceEquals(tm._managedThread, Thread.CurrentThread))
                    {
                        ApplicationTask currentTask;
                        if ((currentTask = tm.CurrentApplicationTask) != null)
                        {
                            if (sm == null || !currentTask.CurrentSessionMetrics.SessionGUID.Equals(sm.SessionGUID))
                            {
                                currentTask.Active = !tm.Suspended;
                                yield return currentTask;
                            }
                        }
                    }
                }
            }
        }
    }
