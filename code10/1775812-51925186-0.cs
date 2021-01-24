    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
    try
    {
    	await Task.Delay(TimeSpan.FromSeconds(5), cts.Token)
    		.ContinueWith(t => Console.WriteLine("Continued"), TaskContinuationOptions.NotOnCanceled);
    	Console.WriteLine("Hihi...");
    }
    catch (OperationCanceledException)
    {
    	Console.WriteLine("Cancelled");
    }
    Console.ReadLine();
