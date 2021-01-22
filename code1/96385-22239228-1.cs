    public static async Task<T> DoAsync<T>(Func<T> action, TimeSpan retryInterval, int retryCount = 3)
		{
			var exceptions = new List<Exception>();
			for (int retry = 0; retry < retryCount; retry++)
			{
				try
				{
					return await (dynamic)action();
				}
				catch (Exception ex)
				{
					exceptions.Add(ex);
				}
				await Task.Delay(retryInterval);
			}
			throw new AggregateException(exceptions);
		}
