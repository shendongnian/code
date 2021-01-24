        private static readonly SemaphoreLocker _semaphoreLocker = new SemaphoreLocker();
        public async Task<List<TResult>> ExecuteStoredProcedureWithLockAsync<TResult>(string storedProcedureName, object parameters, CancellationToken cancellationToken) where TResult : new()
        {
            List<TResult> result = new List<TResult>();
            await _semaphoreLocker.LockAsync(async () =>
            {
                result = await ExecuteStoredProcedureAsync<TResult>(storedProcedureName, parameters, cancellationToken);
            }, cancellationToken);
            return result;
        }
        private Object _locker = new Object();
        public List<TResult> ExecuteStoredProcedureWithLock<TResult>(string storedProcedureName, object parameters) where TResult : new()
        {
            lock (_locker)
            {
                return ExecuteStoredProcedure<TResult>(storedProcedureName, parameters);
            }
        }
