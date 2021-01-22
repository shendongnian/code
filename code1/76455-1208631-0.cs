		private bool running = true;
		private AutoResetEvent waiter = new AutoResetEvent(false);
		public void Run()
		{
			FileSystemWatcher watcher = new FileSystemWatcher("C:\\test");
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
				// do something with changes
			}
		}
		public void Stop()
		{
			running = false;
			waiter.Set();
		}
