	static void Main(string[] args)
	{
		const string globalName = "MyProgramName";//same unique name
		bool isNew = false;
		EventWaitHandle mreStarted = new EventWaitHandle(false, EventResetMode.ManualReset, globalName, out isNew);
		try
		{
			if (!isNew)
				mreStarted.Set();
			Application.Run(new Form());
		}
		finally
		{
			mreStarted.Close();
		}
	}
