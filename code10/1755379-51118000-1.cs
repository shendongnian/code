	void Main()
	{
		string file = @"C:\Data\foo.txt";
		
		using (var timer = new System.Timers.Timer())
		{
			timer.Interval = 2000; // 2 second interval
			timer.Elapsed += OnTimedEvent; // attach delegate
			timer.Enabled = true; // start the timer	
	
			// open the file
			using (var monitor = new FileMonitor(file))
			{
				_lines = monitor.Lines;
				
				 // loop forever, remove this
				while (true) { }
			}
		}
	}
	
	public void OnTimedEvent(object sender, EventArgs e)
	{
		// just for debugging, you should remove this
		Console.WriteLine($"current count: {_lines.Count()}");
	}
