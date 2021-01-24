        private async Task ThrottleDatabaseQueryAsync(Task task)
        {
            await ThrottleDatabaseQuerySemaphore.WaitAsync();
            try
            {
                lock (MetricsLock)
                {
                    AsyncCount++;
                    if (AsyncCount > MaxAsyncCount)
                        MaxAsyncCount = AsyncCount;
                }
                await task;
            }
            finally
            {
                ThrottleDatabaseQuerySemaphore.Release();
                lock (MetricsLock)
                    AsyncCount--;
            }
        }
    }
