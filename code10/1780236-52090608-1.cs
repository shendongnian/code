    bool isComplete = false;
	System.Threading.Tasks.Task.Run(() => PerformTask(ref isComplete));
	
	while (!isComplete)
	{
		Console.WriteLine("Running...");
		System.Threading.Thread.Sleep(1000);
	}
