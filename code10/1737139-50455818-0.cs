	public class SampleMetrics
	{
		private readonly Timer timer = Metric.Timer("Requests", Unit.Requests);
		private readonly Counter counter = Metric.Counter("ConcurrentRequests", Unit.Requests);
		public void Request(int i)
		{
			this.counter.Increment();
			using (this.timer.NewContext()) // measure until disposed
			{
				// do some work
			}
			this.counter.Decrement();
		}
	}
