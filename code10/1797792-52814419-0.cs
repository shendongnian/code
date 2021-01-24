	public static IEnumerable<int> GetItems()
	{
		return EnumerableEx.Create<int>(async y =>
		{
			while (await ShouldLoopAsync())
			{
				await y.Return(GetItemAsync());
			}
			await y.Break();
		});
	}
