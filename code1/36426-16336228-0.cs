    public static TResult Using<T, TResult>(this T client, Func<T, TResult> work)
			where T : ICommunicationObject
		{
			try
			{
				var result = work(client);
				client.Close();
				return result;
			}
			catch (Exception e)
			{
				client.Abort();
				throw;
			}
		}
