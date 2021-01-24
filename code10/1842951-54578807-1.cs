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
                        concreteTask.ContinueWith(RemoveTask);
                        _currentTask = concreteTask;
                    }
                }
            }
            return _currentTask;
        }
        private void RemoveTask()
        {
            _currentTask = null;
        }
    }
