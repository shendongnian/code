	void Main()
	{
		var iDelayInMilliseconds = 4000;
		
		IObservable<int> query =
			from x in Observable.StartAsync(() => SomeMethod())
			from y in Observable.Timer(TimeSpan.FromMilliseconds(iDelayInMilliseconds))
			from z in Observable.Start(() => AnotherMethod())
			select x + z;
			
		Task<int> task = query.ToTask();
		
		Console.WriteLine(task.Result);
	}
	
	public async Task<int> SomeMethod() => await Task.Run(() => 1);
	public int AnotherMethod() => 2;
