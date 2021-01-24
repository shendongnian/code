	void Main()
	{
		var generator = new EventGenerator();
		var observable = Observable.FromEventPattern<EventHandler<bool>, bool>(
					h => generator.MyEvent += h,
					h => generator.MyEvent -= h);
					
		observable
			.Throttle(TimeSpan.FromSeconds(1))
			.Subscribe(s =>
			{
				Console.WriteLine("doing something");
			});
	
		// simulate rapid firing event
		for(int i = 0; i <= 100; i++)
			generator.RaiseEvent();	
		// when no longer interested, dispose the subscription	
		subscription.Dispose();	
	}
	
	public class EventGenerator
	{
		public event EventHandler<bool> MyEvent;
	
		public void RaiseEvent()
		{
			if (MyEvent != null)
			{
				MyEvent(this, false);
			}
		}
	}
