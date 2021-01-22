	ChannelServer.ListeningThread = new Thread(new ThreadStart(delegate()
	{
		Log.Inform("Waiting for clients on thread {0}.", Thread.CurrentThread.ManagedThreadId);
		while (true)
		{
			try
			{
				ChannelServer.ClientConnected.Reset();
				ChannelServer.Listener.BeginAcceptSocket(new AsyncCallback(ChannelClientHandler.EndAcceptSocket), ChannelServer.Listener);
				ChannelServer.ClientConnected.WaitOne();
			}
			catch (ThreadInterruptedException)
			{
				Log.Inform("Interrupted client listening thread {0}.", Thread.CurrentThread.ManagedThreadId);
				break;
			}
		}
	}));
	ChannelServer.ListeningThread.Start();
