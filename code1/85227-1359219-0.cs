            try
            {
                Monitor.Enter(QueueModifierLockObject);
                DownloadFile toReturn = queue.Dequeue();         
                return toReturn;
            }
            finally
            {
                Monitor.Exit(QueueModifierLockObject);
            }
