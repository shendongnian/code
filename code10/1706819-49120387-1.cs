	[Fact]
	public void MethodName()
	{
		var testScheduler = new TestScheduler();
		var hotObservable = testScheduler.CreateHotObservable(
			OnNext(10, 1), 
			OnNext(20, 1), 
			OnNext(30, 1), 
			OnNext(40, 1)
		);
		var ts = TimeSpan.FromTicks(20);
		hotObservable
			.GroupBy(i => i) 			//comparison key
			.Select(g => g.TimeDrained(ts, testScheduler))
			.Merge()
			.Subscribe(i => Console.WriteLine($"{testScheduler.Clock}-{i}"));
		testScheduler.AdvanceBy(160);
	}
