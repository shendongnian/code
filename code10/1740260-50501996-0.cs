    private static async void PerformLoop()
	{
		Stopwatch timer = new Stopwatch();
		timer.Start();
		List<Task> l = new List<Task>();
		for (int i = 0; i < 50; i++)
		{
			l.Add(DoSomethingAsync(i));
		}
		await Task.WhenAll(l);
		timer.Stop();
		Console.WriteLine(timer.Elapsed.TotalSeconds);
	}
