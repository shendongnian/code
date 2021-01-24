	void Main()
	{
		var iDelayInMilliseconds = 4000;
		
		IObservable<int> query =
			from x in Observable.Start(() => SomeMethod())
			from y in Observable.Timer(TimeSpan.FromMilliseconds(iDelayInMilliseconds))
			from z in Observable.Start(() => AnotherMethod())
			select x + z;
			
		IDisposable subscription = query.Subscribe(w => Console.WriteLine(w));
	}
	
	public int SomeMethod() => 1;
	public int AnotherMethod() => 2;
