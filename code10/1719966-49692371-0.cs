	public class TaskDebouncer<TResult>
	{
		public delegate void TaskDebouncerHandler(TResult result, object sender);
		public event TaskDebouncerHandler OnCompleted;
		public event TaskDebouncerHandler OnDebounced;
		private Task _lastTask;
		private object _lock = new object();
		public void Run(Task<TResult> task)
		{
			lock (_lock)
			{
				_lastTask = task;
			}
			task.ContinueWith(t =>
			{
				if (t.IsFaulted)
					throw t.Exception;
				lock (_lock)
				{
					if (_lastTask == task)
					{
						OnCompleted?.Invoke(t.Result, this);
					}
					else
					{
						OnDebounced?.Invoke(t.Result, this);
					}
				}
			});
		}
		
		public async Task WaitLast()
		{
			await _lastTask;
		}
	}
