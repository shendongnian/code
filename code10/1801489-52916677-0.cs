		private SemaphoreSlim _processSemaphore = new SemaphoreSlim(10);
		private int _concurrency;
		private TaskCompletionSource<int> _source;
		private ManualResetEvent _awaitor;
		public void Start()
		{
			//solution 1
			_concurrency = 0;
			_source = new TaskCompletionSource<int>();
			_shuttingDown = false;
			//solution 2
			_awaitor = new ManualResetEvent(false);
			//your code
		}
		public async Task<Modification> Process(IList<Command> commands)
		{
			Interlocked.Increment(ref _concurrency);
			Assert.IsFalse(_shuttingDown, "Server is in shutdown phase");
			await _processSemaphore.WaitAsync();
			try
			{
				// threads that have reached this far must be allowed to complete
				return _database.Process(commands);
			}
			finally
			{
				_processSemaphore.Release();
				//check and release
				int concurrency = Interlocked.Decrement(ref _concurrency);
				if (_shuttingDown && concurrency == 0)
				{
					//solution 1
					_source.TrySetResult(0);
					//solution 2
					_awaitor.Set();
				}
			}
		}
		public async Task StopAsync()
		{
			_shuttingDown = true;
			// how wait for threads to complete without cancelling?
			if (Interlocked.CompareExchange(ref _concurrency, 0, 0) != 0)
			{
				await _source.Task;//solution 1
				_awaitor.WaitOne();//solution 2
			}
		}
