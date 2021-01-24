	private static System.Threading.Timer _timer;
	static void Main(string[] args)
	{
	  // start the timer
	  _timer = new System.Threading.Timer(checkDirectoriesForAppsToRun, null, 0, timeToPause);
	}
	static void StopTimer()
	{
	  // call this method when you want to stop the timer
	  _timer?.Dispose();
	}
	static void checkDirectoriesForAppsToRun(object state)
	{
	  Console.WriteLine("Starting apps...");
	  /* exising code not considered in this answer... */
	  Console.WriteLine("Check completed next run at " + DateTime.Now.Add(timeToPause).ToShortTimeString());
	  // await Task.Delay(timeToPause); // removed
	}
	
