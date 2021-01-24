    public static class TaskExtensions
    {
    
        public static async Task<Task> WhenFirst(params Task[] tasks)
        {
            if (tasks == null)
            {
                throw new ArgumentNullException(nameof(tasks), "Must be supplied");
            }
            else if (tasks.Length == 0)
            {
                throw new ArgumentException("Must supply at least one task", nameof(tasks));
            }
    
            int finishedTaskIndex = -1;
            for (int i = 0, j = tasks.Length; i < j; i++)
            {
                var task = tasks[i];
                if (task == null)
                    throw new ArgumentException($"Task at index {i} is null.", nameof(tasks));
    
                if (finishedTaskIndex == -1 && task.IsCompleted && task.Status == TaskStatus.RanToCompletion)
                {
                    finishedTaskIndex = i;
                }
            }
    
            if (finishedTaskIndex == -1)
            {
                var promise = new TaskAwaitPromise(tasks.ToList());
                for (int i = 0, j = tasks.Length; i < j; i++)
                {
                    if (finishedTaskIndex == -1)
                    {
                        var taskId = i;
    #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                        //we dont want to await these tasks as we want to signal the first awaited task completed.
                        tasks[i].ContinueWith((t) =>
                        {
                            if (t.Status == TaskStatus.RanToCompletion)
                            {
                                if (finishedTaskIndex == -1)
                                {
                                    finishedTaskIndex = taskId;
                                    promise.InvokeCompleted(taskId);
                                }
                                    
                            }
                            else
                                promise.InvokeFailed();
                        });
    #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    
                    }
    
                }
                return await promise.WaitCompleted();
            }
    
    
            return Task.FromResult(finishedTaskIndex > -1 ? tasks[finishedTaskIndex] : null);
        }
    
        class TaskAwaitPromise
        {
            IList<Task> _tasks;
            int _taskId = -1;
            int _taskCount = 0;
            int _failedCount = 0;
    
    
            public TaskAwaitPromise(IList<Task> tasks)
            {
                _tasks = tasks;
                _taskCount = tasks.Count;
                GC.KeepAlive(_tasks);
            }
    
            public void InvokeFailed()
            {
                _failedCount++;
            }
    
            public void InvokeCompleted(int taskId)
            {
                if (_taskId < 0)
                {
                    _taskId = taskId;
                }
            }
    
            public async Task<Task> WaitCompleted()
            {
                await Task.Delay(0);
    
                while (_taskId < 0 && _taskCount != _failedCount)
                {
    
                }
                return _taskId > 0 ? _tasks[_taskId] : null;
            }
    
        }
    
    }
