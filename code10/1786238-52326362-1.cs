    public class MyMonitor
    {
        IProgress<sring> _progress;
        public MyMonitor(IProgress<string> progress,...)
        {
            ....
            _progress=progress;
        }
    	public void StartMonitoring(IProgress<string> progress)
	    {
            ...
    	    taskTimer.Elapsed += delegate
	        {
	            //call DeviceController here//
    	        //do stuff//
	            //something went wrong//
	            _progress.Report("Something went wrong";);
	        };
	        taskTimer.Start();
        }
	}
