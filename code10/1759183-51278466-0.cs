    public class FifoSemaphore : IDisposable
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0, 1);
        private readonly Queue<TaskCompletionSource<object>> _taskQueue = new Queue<TaskCompletionSource<object>>(10);
        private readonly object _lockObject = new object();
        public async Task WaitAsync()
        {
            // Enqueue a task
            Task resultTask;
            lock (_lockObject)
            {
                var tcs = new TaskCompletionSource<object>();
                resultTask = tcs.Task;
                _taskQueue.Enqueue(tcs);
            }
            // Wait for the lock
            await _semaphore.WaitAsync();
            // Dequeue the next item and set it to resolved (release back to API call)
            TaskCompletionSource<object> queuedItem;
            lock (_lockObject)
            {
                queuedItem = _taskQueue.Dequeue();
            }
            queuedItem.SetResult(null);
            // Await our own task
            await resultTask;
        }
        public void Release()
        {
            // Release the semaphore so another waiting thread can enter
            _semaphore.Release();
        }
        public void Dispose()
        {
            _semaphore?.Dispose();
        }
    }
