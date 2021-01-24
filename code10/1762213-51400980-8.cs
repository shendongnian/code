	void Main()
	{
		WatchForUnobservedTaskExceptions();
	
		var task = Task.Factory.StartNew(async () =>
		{
			await Task.Delay(1000);
			throw new InvalidOperationException();
		});
	
		IgnoreExceptions(task);
	
		GC.Collect(2);
		GC.WaitForPendingFinalizers();
	
		Console.ReadLine();
	}
	
	private void WatchForUnobservedTaskExceptions()
	{
		TaskScheduler.UnobservedTaskException += (sender, args) =>
		{
			args.Exception.Dump("Ooops");
		};
	}
	
	public static Task IgnoreExceptions(Task task)
	  => task.ContinueWith(t =>
		  {
			  var ignored = t.Exception.Dump("Checked");
		  },
		  CancellationToken.None,
		  TaskContinuationOptions.ExecuteSynchronously,
		  TaskScheduler.Default);
	
	public static Task IgnoreExceptions(Task<Task> task)
	=> task.Unwrap().ContinueWith(t =>
	{
		var ignored = t.Exception.Dump("Checked");
	},
	CancellationToken.None,
	TaskContinuationOptions.ExecuteSynchronously,
	TaskScheduler.Default);
