	void Main()
	{
		var r = new Random();
		
		IEnumerable<Task<int>> source =
			Enumerable
				.Range(0, 10).Select(x => Task.Factory.StartNew(() =>
		{
			Thread.Sleep(r.Next(10000));
			if (x % 3 == 0) throw new NotSupportedException($"Failed on {x}");
			return x;
		}));
	
		IObservable<Notification<int>> query = source.ToObservable();
	
		query
			.Do(x =>
			{
				if (x.Kind == NotificationKind.OnError)
				{
					Console.WriteLine(x.Exception.Message);
				}
			})
			.Where(x => x.Kind == NotificationKind.OnNext) // Only care about vales
			.Select(x => x.Value)
			.Subscribe(x => Console.WriteLine(x), () => Console.WriteLine("Done."));
	}
	
	public static class Ex
	{
		public static IObservable<Notification<T>> ToObservable<T>(this IEnumerable<Task<T>> source)
		{
			return source.Select(t => t.ToObservable().Materialize()).Merge();
		}
	}
