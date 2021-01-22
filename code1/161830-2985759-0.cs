	private class Worker : IDisposable
	{
		private readonly TimeSpan _interval;
		private WorkerContext _workerContext;
		private sealed class WorkerContext
		{
			private readonly ManualResetEvent _evExit;
			private readonly Thread _thread;
			private readonly TimeSpan _interval;
			public WorkerContext(ParameterizedThreadStart threadProc, TimeSpan interval)
			{
				_evExit = new ManualResetEvent(false);
				_thread = new Thread(threadProc);
				_interval = interval;
			}
			public ManualResetEvent ExitEvent
			{
				get { return _evExit; }
			}
			public TimeSpan Interval
			{
				get { return _interval; }
			}
			public void Run()
			{
				_thread.Start(this);
			}
			public void Stop()
			{
				_evExit.Set();
			}
			public void StopAndWait()
			{
				_evExit.Set();
				_thread.Join();
			}
		}
		~Worker()
		{
			Stop();
		}
		public Worker(TimeSpan interval)
		{
			_interval = interval;
		}
		public TimeSpan Interval
		{
			get { return _interval; }
		}
		private void DoWork()
		{
			/* do your work here */
		}
		public void Start()
		{
			var context = new WorkerContext(WorkThreadProc, _interval);
			if(Interlocked.CompareExchange<WorkerContext>(ref _workerContext, context, null) == null)
			{
				context.Run();
			}
			else
			{
				context.ExitEvent.Close();
				throw new InvalidOperationException("Working alredy.");
			}
		}
		public void Stop()
		{
			var context = Interlocked.Exchange<WorkerContext>(ref _workerContext, null);
			if(context != null)
			{
				context.Stop();
			}
		}
		private void WorkThreadProc(object p)
		{
			var context = (WorkerContext)p;
			// you can use whatever time-measurement mechanism you want
			var sw = new System.Diagnostics.Stopwatch();
			int sleep = (int)context.Interval.TotalMilliseconds;
			while(true)
			{
				if(context.ExitEvent.WaitOne(sleep)) break;
					
				sw.Reset();
				sw.Start();
				DoWork();
					
				sw.Stop();
					
				var time = sw.Elapsed;
				if(time < _interval)
					sleep = (int)(_interval - time).TotalMilliseconds;
				else
					sleep = 0;
			}
			context.ExitEvent.Close();
		}
		public void Dispose()
		{
			Stop();
			GC.SuppressFinalize(this);
		}
	}
