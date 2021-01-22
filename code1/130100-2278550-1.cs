	public class TimerPlus : IDisposable
	{
		private readonly TimerCallback _realCallback;
		private readonly Timer _timer;
		private TimeSpan _period;
		private DateTime _next;
		public TimerPlus(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
		{
			_timer = new Timer(Callback, state, dueTime, period);
			_realCallback = callback;
			_period = period;
			_next = DateTime.Now.Add(dueTime);
		}
		private void Callback(object state)
		{
			_next = DateTime.Now.Add(_period);
			_realCallback(state);
		}
		public TimeSpan Period
		{
			get
			{
				return _period;
			}
		}
		public DateTime Next
		{
			get
			{
				return _next;
			}
		}
		public TimeSpan DueTime
		{
			get
			{
				return _next - DateTime.Now;
			}
		}
		public bool Change(TimeSpan dueTime, TimeSpan period)
		{
			_period = period;
			_next = DateTime.Now.Add(dueTime);
			return _timer.Change(dueTime, period);
		}
		public void Dispose()
		{
			_timer.Dispose();
		}
	}
