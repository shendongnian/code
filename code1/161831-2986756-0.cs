	public static Thread StartTimer(TimeSpan interval, Func<bool> operation)
	{
		Thread t = new Thread(new ThreadStart(
			delegate()
			{
				DateTime when = DateTime.Now;
				TimeSpan wait = interval;
				while (true)
				{
					Thread.Sleep(wait);
					if (!operation())
						return;
					DateTime dt = DateTime.Now;
					when += interval;
					while (when < dt)
						when += interval;
					wait = when - dt;
				}
			}
		));
		t.IsBackground = true;
		t.Start();
		return t;
	}
