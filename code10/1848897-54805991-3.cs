	public static async Task AsyncMain(CancellationToken token)
	{
		Console.WriteLine("In Thread at Start");
		await Task.Delay(10);
		if(!token.IsCancellationRequested)
		{
			//await Clients.Caller.SendAsync("NoUsersFound");
			Console.WriteLine("Not Cancelled");
		}
		else
		{
			Console.WriteLine("Cancelled");
		}
	}
