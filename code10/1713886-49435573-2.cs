	static void Main()
	{
		var collection = new BlockingCollection<int>(100);
		Task.Run(()=>
		{
			foreach (var element in Enumerable.Range(0, 100_000))
			{
				collection.Add(element);
			}
			collection.CompleteAdding();
		});
		
		Parallel.ForEach(
			collection, 
			new ParallelOptions { MaxDegreeOfParallelism = 2},
			i => Console.WriteLine(i));
		
		Console.WriteLine("Done");
	}
