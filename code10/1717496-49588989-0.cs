    var source = new CancellationTokenSource();
	var task = Task.Run(() => Task.Delay(5000, source.Token));
	source.Cancel();
		
	try 
	{
		task.Wait();
	} 
	catch (AggregateException ex) 
	{
		foreach(var inner in ex.InnerExceptions) 
		{
			// System.Threading.Tasks.TaskCanceledException
			Console.WriteLine(inner.GetType());
		}
	}
