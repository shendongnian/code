	var query =
		Observable
			.Interval(TimeSpan.FromSeconds(1.0))
			.Take(3)
			.Publish()
			.RefCount();
			
	var s1 = query.Subscribe(Console.WriteLine);
	Thread.Sleep(2500);
	var s2 = query.Subscribe(Console.WriteLine);
	Thread.Sleep(2500);
	s1.Dispose();
	s2.Dispose();
	var s3 = query.Subscribe(Console.WriteLine);
	Thread.Sleep(2500);
	s3.Dispose();
