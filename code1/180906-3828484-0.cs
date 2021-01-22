	public IObjectServer OpenServer()
	{
		Logger.Debug("Waiting to open db4o server.");
		var attempts = 0;
		do
		{
			try
			{
				return Db4oFactory.OpenServer(fileName, 0);
			}
			catch (DatabaseFileLockedException ex)
			{
				attempts++;
				if (attempts > 10)
				{
					throw new Exception("Couldn't open db4o server. Giving up!", ex);
				}
				Logger.Warn("Couldn't open db4o server. Trying again in 5sec.");
				Thread.Sleep(5.Seconds());
			}
		} while (true);
	}
