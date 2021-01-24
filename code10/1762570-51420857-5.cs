	public ViewModel()
	{
		SearchTextStream
			.ObserveOn(System.Reactive.Concurrency.Scheduler.Default)
			.SelectMany(searchText => _search(searchText))
			.ObserveOnDispatcher()
			.Subscribe(items =>
			{
				/* do something with `items` */
			}, ex =>
			{
				//handle error
			});
	}
