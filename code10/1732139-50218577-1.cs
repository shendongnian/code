	public class SingletonThing
	{
		private readonly Subject<EventNotification> _subject = new Subject<EventNotification>();
		public void SendEventsAsync(IEnumerable<EventNotification> events)
		{
			foreach (var element in events)
			{
				_subject.OnNext(element);
			}
		}
        //not necessary to expose, but could be helpful
		public IObservable<EventNotification> AllEvents => _subject.AsObservable();
	
		private int idealBatchSize = 10000;
		private TimeSpan maxTimeDelay = TimeSpan.FromSeconds(60);
		public IObservable<IList<EventNotification>> BatchedEvents => _subject
			.Buffer(maxTimeDelay, idealBatchSize);
	}
