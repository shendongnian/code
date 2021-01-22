	private bool running = true;
	private AutoResetEvent waiter = new AutoResetEvent(false);
	public void Run()
	{
		FileSystemWatcher watcher = new FileSystemWatcher("C:\\");
		FileSystemEventArgs changes = null;
		watcher.Changed +=
			(object sender, FileSystemEventArgs e) => {
				changes = e;
				waiter.Set();
			};
		watcher.EnableRaisingEvents = true;
		while (running)
		{
			waiter.WaitOne();
			if (!running) break;
			Console.WriteLine("Path: {0}, Type: {1}",
					changes.FullPath, changes.ChangeType);
		}
		Console.WriteLine("Thread complete");
	}
	public void Stop()
	{
		running = false;
		waiter.Set();
	}
