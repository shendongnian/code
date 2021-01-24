    public class TaskManager<T>
    {
        private Task<T> _currentTask;
        private object _lock = new object();
        public Task<T> ExecuteOnceAsync(string taskId, Func<Task<T>> taskFactory)
        {
            if (_currentTask == null)
            {
                lock (_lock)
                {
                    if (_currentTask == null)
                    {
                        Task<T> concreteTask = taskFactory();
                        _currentTask = concreteTask;
                        _currentTask.ContinueWith(_ => _currentTask = null);
                    }
                }
            }
            return _currentTask;
        }
    }
