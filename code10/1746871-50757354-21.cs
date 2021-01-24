		return await CollectionAccessor.ExecuteWithinScope(async collection =>
		{
			Console.WriteLine("8");
			var adapter = new AsyncSearchAdapter();
			Console.WriteLine("9");
			var result = await adapter.GetSearchAsync();
			Console.WriteLine("19");
			Console.WriteLine(result);
			Console.WriteLine("20");
			
			collection.Dispose();  //// Disposing!
			return "";
		});
