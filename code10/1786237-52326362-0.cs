	public void StartMonitoring(IProgress<string> progress)
	{
	    var _schedule = DateTime.Now;
	    var _nextTaskSched = _schedule.AddSeconds(10);
	    var _timerTicks = (_nextTaskSched - DateTime.Now).TotalMilliseconds;
	    var taskTimer = new Timer(_timerTicks);
	    taskTimer.Elapsed += delegate
	    {
	        //call DeviceController here//
	        //do stuff//
	        //something went wrong//
	        progress.Report("Something went wrong";);
	    };
	    taskTimer.Start();
	}
