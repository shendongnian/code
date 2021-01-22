    public void LongMethod()
	{
		//do stuff
	}
    public void ImpatientMethod()
	{
		Action longMethod = LongMethod; //use Func if you need a return value
		ManualResetEvent mre = new ManualResetEvent(false);
		Thread actionThread = new Thread(new ThreadStart(() =>
		{
			var iar = longMethod.BeginInvoke(null, null);
			longMethod.EndInvoke(iar); //always call endinvoke
			mre.Set();
		}));
		actionThread.Start();
		mre.WaitOne(30000); // waiting 30 secs (or less)
		if (actionThread.IsAlive) actionThread.Abort();
	}
