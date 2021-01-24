	public static async Task MainAsync()
	{
		var actions = new List<Func<Task>>
		{
			Foo, Bar
		};
		var tasks = actions.Select( x => x() );
		await Task.WhenAll(tasks);
	}
	
