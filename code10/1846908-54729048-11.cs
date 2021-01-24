	void Main()
	{
		var foo = new Foo();
		
		IObservable<EventPattern<EventArgs>> bar =
			Observable
				.FromEventPattern<EventHandler, EventArgs>(
					h => foo.Bar += h,
					h => foo.Bar -= h);
		
		var query =
			from ep in bar
			from name in Observable.FromAsync(() => GetNameAsync()) // async Task<string> GetNameAsync()
			from data in Observable.Start(() => LoadData(name)) // string LoadData(string name)
			select new { name, data };
		
		var subscription =
			query
				.Subscribe(x => Console.WriteLine($"{x.name} = {x.data}"));
	}
