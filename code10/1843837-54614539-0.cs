	public async Task<List<string>> GetAccountsAsync()
	{
		await Task.Delay(1500);
		return new List<string> { "40701", "40702", "40703", "40704", "40705" };
	}
	
	private Random _rnd = new Random();
	
	public async Task<int> AddAccount(string account)
	{
		await Task.Delay(1000);
	
		if (_rnd.NextDouble() > 0.5)
		{
			return _rnd.Next(100);
		}
		else
		{
			Console.WriteLine("!");
			throw new InvalidOperationException($"Account {account} was not added");
		}
	}
