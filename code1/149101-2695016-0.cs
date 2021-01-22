ReaderWriterLockSlim rwls;
AutoResetEvent are;
public void Enqueue(ITask task) {
    rwls.EnterWriteLock();
    try {
        underlying.Enqueue(task);
        if (underlying.Count == 1) {
          are.Set();
        }
    } finally {
        rwls.ExitWriteLock();
    }
}
private void DequeueForProcessing(object state) {
    while (true) {
        ITask task;
        rwls.EnterWriteLock();
        try {
            while (underlying.Count == 0) {
                rwls.ExitWriteLock();
                are.WaitOne();
                rwls.EnterWriteLock();
            }
            task = underlying.Dequeue();
        } finally {
            rwls.ExitWriteLock();
        }
        Process(task);
    }
}
