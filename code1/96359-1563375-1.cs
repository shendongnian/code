    RetryForExcpetionType(DoSomething, typeof(TimeoutException), 5, 1000);
		public static void RetryForExcpetionType(Action action, Type retryOnExceptionType, int numRetries, int retryTimeout)
		{
			if (action == null)
				throw new ArgumentNullException("action");
			if (retryOnExceptionType == null)
				throw new ArgumentNullException("retryOnExceptionType");
			while (true)
			{
				try
				{
					action();
					return;
				}
				catch(Exception e)
				{
					if (--numRetries <= 0 || !retryOnExceptionType.IsAssignableFrom(e.GetType()))
						throw;
					if (retryTimeout > 0)
						System.Threading.Thread.Sleep(retryTimeout);
				}
			}
		}
