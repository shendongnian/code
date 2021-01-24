	public static async Task<bool> ConnectAsyncWithTimeout(this Socket socket, string host, int port, int timeout = 0)
	{
		if (timeout < 0)
			throw new ArgumentOutOfRangeException("timeout");
		try
		{
			var connectTask = socket.ConnectAsync(host, port);
			var res = await Task.WhenAny(connectTask, Task.Delay(timeout));
			await res;
			return connectTask == res && connectTask.IsCompleted && !connectTask.IsFaulted;
		} 
		catch(SocketException se)
		{
			return false;
		}
	}
