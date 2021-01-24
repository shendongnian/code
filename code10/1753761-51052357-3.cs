	static IObservable<OutputParameters> Poll()
	{
		const int steps = 10;
		return Observable.Defer<OutputParameters>(() =>
		{
			var id = Guid.NewGuid();
			return Observable.Generate(1, i => i <= steps, i => i + 1, i => i,
					_ => TimeSpan.FromMilliseconds(1000), new EventLoopScheduler())
				.Do(i => Console.WriteLine($"[IN THREAD] Thread {id}: Step {i} of {steps}"))
				.Select(i => new OutputParameters { Id = id, Value = i });
		});
	}
