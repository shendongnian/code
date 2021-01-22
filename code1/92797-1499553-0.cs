	static void Main(string[] args)
	{
		const string globalName = "MyProgramName";//something unique
		bool isNew = false;
		ManualResetEvent mreExited = new ManualResetEvent(false);
		EventWaitHandle mreStarted = new EventWaitHandle(false, EventResetMode.ManualReset, globalName, out isNew);
		try
		{
			if (!isNew)//already running, just exit?
				return;
			//start and monitor for exit
			Process pstarted = Process.Start("...");
			pstarted.Exited += delegate(object o, EventArgs e) { mreExited.Set(); };
			pstarted.EnableRaisingEvents = true;
			int index = WaitHandle.WaitAny(new WaitHandle[] { mreExited, mreStarted });
			if (index == 0)//mreExited signaled
				throw new ApplicationException("Failed to start application.");
		}
		finally
		{
			mreExited.Close();
			mreStarted.Close();
		}
	}
