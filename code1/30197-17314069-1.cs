	public static TResult ExecuteOOMAware<T1, T2, TResult>(Func<T1,T2 ,TResult> func, T1 a1, T2 a2)
	{
		int oomCounter = 0;
		int maxOOMRetries = 10;
		do
		{
			try
			{
				return func(a1, a2);
			}
			catch (OutOfMemoryException)
			{
				oomCounter++;
				if (maxOOMRetries > 10)
				{
					throw;
				}
				else
				{
					Log.Info("OutOfMemory-Exception caught, Trying to fix. Counter: " + oomCounter.ToString());
					System.Threading.Thread.Sleep(TimeSpan.FromSeconds(oomCounter * 10));
					GC.Collect();
				}
			}
		} while (oomCounter < maxOOMRetries);
		// never gets hitted.
		return default(TResult);
	}
