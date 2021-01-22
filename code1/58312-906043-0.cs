    AppDomain.CurrentDomain.ProcessExit +=
	delegate(object sender, EventArgs e)
	{
		Console.WriteLine("Process Exit");
	};
    Thread t1 = new Thread(new ThreadStart(delegate
    {
	try
	{
		while (true)
		{
			Console.WriteLine("test 1");
			Thread.Sleep(500);
		}
	}
	finally
	{
		Console.WriteLine("Terminating t1");
	}
    }));
    Thread t2 = new Thread(new ThreadStart(delegate
    {
	try
	{
		while (true)
		{
			Console.WriteLine("test 2");
			Thread.Sleep(500);
		}
	}
	finally
	{
		Console.WriteLine("Terminating t2");
	}
    }));
    t1.Start();
    t2.Start();
    Thread.Sleep(2000);
    t2.Abort();
    t2.Join();
    Environment.Exit(1);
