	public static void Main(string[] args)
	{
		string who = "www.google.com";
		AutoResetEvent waiter = new AutoResetEvent(false);
		Ping pingSender = new Ping();
		// When the PingCompleted event is raised,
		// the PingCompletedCallback method is called.
		pingSender.PingCompleted += PingCompletedCallback;
		// Create a buffer of 32 bytes of data to be transmitted.
		string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
		byte[] buffer = Encoding.ASCII.GetBytes(data);
		// Wait 12 seconds for a reply.
		int timeout = 12000;
		// Set options for transmission:
		// The data can go through 64 gateways or routers
		// before it is destroyed, and the data packet
		// cannot be fragmented.
		PingOptions options = new PingOptions(64, true);
		Console.WriteLine("Time to live: {0}", options.Ttl);
		Console.WriteLine("Don't fragment: {0}", options.DontFragment);
		// Send the ping asynchronously.
		// Use the waiter as the user token.
		// When the callback completes, it can wake up this thread.
		pingSender.SendAsync(who, timeout, buffer, options, waiter);
		// Prevent this example application from ending.
		// A real application should do something useful
		// when possible.
		waiter.WaitOne();
		Console.WriteLine("Ping example completed.");
	}
	public static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
	{
		// If the operation was canceled, display a message to the user.
		if (e.Cancelled)
		{
			Console.WriteLine("Ping canceled.");
			// Let the main thread resume. 
			// UserToken is the AutoResetEvent object that the main thread 
			// is waiting for.
			((AutoResetEvent)e.UserState).Set();
		}
		// If an error occurred, display the exception to the user.
		if (e.Error != null)
		{
			Console.WriteLine("Ping failed:");
			Console.WriteLine(e.Error.ToString());
			// Let the main thread resume. 
			((AutoResetEvent)e.UserState).Set();
		}
		Console.WriteLine($"Roundtrip Time: {e.Reply.RoundtripTime}");
		// Let the main thread resume.
		((AutoResetEvent)e.UserState).Set();
	}
