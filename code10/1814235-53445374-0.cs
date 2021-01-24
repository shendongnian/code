	var subject = new Subject<Unit>();
	var callback = subject.FirstOrDefaultAsync();
	using (callback.Subscribe(_ => { }, () => Console.WriteLine("Done.")))
	{
		subject.OnNext(Unit.Default);
	}
