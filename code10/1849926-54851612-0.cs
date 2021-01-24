	public void test()
	{
		IObservable<Unit> query =
			Observable
				.Range(1, 1000)
				.SelectMany(i =>
					Observable
						.Start(() => IntensiveWork(i)));
				
		IDisposable subscription = query.Subscribe();
	}
	
	private static Random r = new Random();
	
	private static void IntensiveWork(int i)
	{
		Thread.Sleep(r.Next(i * 1));
	}
