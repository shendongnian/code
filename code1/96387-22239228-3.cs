    public static async Task<T> DoAsync<T>(Func<dynamic> action, TimeSpan retryInterval, int retryCount = 3)
		{
			var exceptions = new List<Exception>();
			for (int retry = 0; retry < retryCount; retry++)
			{
				try
				{
					return await action().ConfigureAwait(false);
				}
				catch (Exception ex)
				{
					exceptions.Add(ex);
				}
				await Task.Delay(retryInterval).ConfigureAwait(false);
			}
			throw new AggregateException(exceptions);
		}
