	private static SerialDisposable _subscriber = new SerialDisposable();
	private static void AddFeed(IObservable<PriceTick> feed)
	{
		_subscriber.Disposable =
			feed
				.Buffer(TimeSpan.FromMilliseconds(_throttleFrequency))
				.SelectMany(buffer =>
					buffer
						.GroupBy(x => x.InstrumentId, (key, result) => result.First()))
				.Subscribe(NotifyClient);
	}
