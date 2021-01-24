    var queue = new ConcurrentQueue<DateTime>();
	var tcs = new CancellationTokenSource();
	var token = tcs.Token;
	Task.Run(async () => {
		for (var i = 0; i < 2; i++) 
		{
			queue.Enqueue(DateTime.Now);
			await Task.Delay(2000);
		}
		tcs.Cancel();
	}, token);
	Task.Run(() => {
		while (!token.IsCancellationRequested) 
		{
			if (queue.Any())
			{
				DateTime result;
				queue.TryDequeue(out result);
				Console.WriteLine($"Received {result}...");
			}
		}
	}, token).ContinueWith(t =>
	{
		Console.WriteLine("Stop");
	});
	Console.ReadLine();
	tcs.Cancel();
