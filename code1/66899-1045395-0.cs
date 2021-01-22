	public sealed class CallBuffer : IDisposable
	{
		
		private readonly TimeSpan _timeSpan;
		private readonly Timer _timer;
		public CallBuffer(Action call, TimeSpan timeSpan)
		{
			_timeSpan = timeSpan;
			_timer = new Timer(state => call());
		}
		public void Buffer()
		{
			_timer.Change(_timeSpan, TimeSpan.FromMilliseconds(-1));
		}
		void IDisposable.Dispose()
		{
			_timer.Dispose();
			GC.SuppressFinalize(this);
		}
	}
