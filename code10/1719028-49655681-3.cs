    private void LogWork(...)
        lock(mSyncObject) {
            Monitor.Pulse(mSyncObject);
            while(Monitor.Wait(mSyncObject)) {
                if (mLogQueue.Count != 0) {
                    LogEntry le = queue.dequeue();
                    // handle log here
                }
                Monitor.Pulse(mSyncObject);
            }
        }
    }
