    var source = new CancellationTokenSource();
	source.CancelAfter(1000);
	var task = Task.Run(() => Task.Delay(5000, source.Token));
		
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
