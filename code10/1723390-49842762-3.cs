	static void Main()
	{
		var server = Task.Factory.StartNew(() => RunServer());
	    var client = Task.Factory.StartNew(() => RunClient());
	    Task.WaitAll(server, client);
	    Console.WriteLine("Done");
	}
