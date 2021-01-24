	private void DoJob(object state)
	{
		Console.WriteLine("Delaying...");
		Thread.Sleep(3000);
		Console.WriteLine("Thread done");
		_countdownEvent.Signal();
	}
	// on some button click event
	_countdownEvent = new CountdownEvent(threadsNumericUpDown.Value);
	for (int i = 0; i < threadsNumericUpDown.Value; i++)
	{
		ThreadPool.QueueUserWorkItem(new WaitCallback(DoJob), i);
	}
	_countdownEvent.Wait();
	Console.WriteLine("Main thread released");
