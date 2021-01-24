	void Main()
	{
		var scheduler = new EventLoopScheduler();
		var loop = scheduler.Schedule(a =>
		{
			UpdateMachineState();
			a();
		});
		
		Thread.Sleep(1);
		
		loop.Dispose();
	}
	
	public void UpdateMachineState()
	{
		Console.Write(".");
	}
